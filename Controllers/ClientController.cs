using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Teatru.Services.ClientServices;
using Teatru.Services.ClientServices.Dto;
using Teatru.Services.RezervareServices;
using Teatru.Services.RezervareServices.Dto;
using Teatru.Services.ScenetaServices;
using Teatru.Services.ScenetaServices.Dto;
using Teatru.Web.ViewModels;

namespace Teatru.Web.Controllers
{
    public class ClientController : Controller
    {
        private readonly IClientService clientService;
        private readonly IScenetaService scenetaService;
        private readonly IRezervareService rezervareService;


        public ClientController(IClientService clientService,  IScenetaService scenetaService, IRezervareService rezervareService)
        {
            this.clientService = clientService;
            this.rezervareService = rezervareService;
            this.scenetaService = scenetaService;
 
        }

        [HttpGet]
        public IActionResult AllClienti()
        {

            var clientiDtos = clientService.GetAllClienti().Select(x => new ClientViewModel
            {
                ID = x.ID,
                Prenume =  x.Prenume,
                Nume = x.Nume,
                Email = x.Email,
                Telefon = x.Telefon
            });
            return View(clientiDtos);
        }

        [HttpGet]
        public IActionResult AllRezervari()
        {
           var rezervareDtos = rezervareService.GetAllRezervari() ?? new List<RezervareDto>();
            var rezervareViewModel = rezervareDtos.Select(x => new RezervareViewModel        
            {
                ID = x.ID,
                Data = x.Data,
                SelectedScenetaID = x.ScenetaID,
                SelectedLocID = x.LocID,
            }).ToList();
            return View(rezervareViewModel);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register([FromForm] ClientViewModel clientViewModel)
        {
            if (clientViewModel == null)
            {
                return RedirectToAction("SomethingWentWrong", "Helpers", new { message = "ClientViewModel is null" });
            }
            if (!ModelState.IsValid)
            {
                return View(clientViewModel);
            }
            if(clientService.GetByEmail(clientViewModel.Email) == true)
            {
                return RedirectToAction("Register", "Client", new {message = "Exista deja un utilizator cu acest email!"} );
            }
            var clientDto = new ClientDto
            {
                Prenume = clientViewModel.Prenume,
                Nume = clientViewModel.Nume,
                Email = clientViewModel.Email,
                Telefon = clientViewModel.Telefon,
            };

            clientService.RegisterClient(clientDto);
            return View("Detail", clientViewModel);
        }

        [HttpGet]
        public IActionResult Rezervare()
        {
            var sceneteDto = scenetaService.GetAll() ?? new List<ScenetaDto>();

            var rezervareViewModel = new RezervareViewModel
            {
                SelectedScenetaID = null,
                Scenete = sceneteDto.Select(x => new SelectListItem { Value = x.ID.ToString(), Text = x.Nume }).ToList(),
            }; 
            return View(rezervareViewModel);
        }

        [HttpPost]
        public IActionResult Rezervare([FromForm] RezervareViewModel rezervareViewModel)
        {
            if(rezervareViewModel == null)
            {
                return RedirectToAction("SomethingWentWrong", "Helpers", new { message = "ClientViewModel is null" });
            }

            var client = clientService.SearchByEmail(rezervareViewModel.Email);
            
            var rezervareDto = new RezervareDto
            {
                Data = rezervareViewModel.Data,
                ClientID = client.ID,
                ScenetaID = rezervareViewModel.SelectedScenetaID,
                LocID = rezervareViewModel.SelectedLocID
            };

            rezervareService.Rezervare(rezervareDto);
            return View("RezervareDetails", rezervareViewModel);
        }
    }
}
