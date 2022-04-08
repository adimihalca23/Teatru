using Microsoft.AspNetCore.Mvc;
using Teatru.Services.ScenetaServices;
using Teatru.Services.ScenetaServices.Dto;
using Teatru.Web.ViewModels;

namespace Teatru.Web.Controllers
{
    public class AdminController : Controller
    {
        private readonly IScenetaService scenetaService;
        public AdminController(IScenetaService scenetaService)
        {
            this.scenetaService = scenetaService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AllSceneteAdmin()
        {
            var sceneteViewModel = scenetaService.GetAll().Select(x => new ScenetaViewModel
            {
                ID = x.ID,
                Nume = x.Nume,
                Gen = x.Gen,
                Durata = x.Durata
            });
            return View(sceneteViewModel);
        }

        [HttpGet]
        public IActionResult AllScenete()
        {
           var sceneteViewModel = scenetaService.GetAll().Select(x => new ScenetaViewModel
            {
                ID = x.ID,
                Nume = x.Nume,
                Gen = x.Gen,
                Durata = x.Durata
            });
            return View(sceneteViewModel);
        }

        [HttpGet]
        public IActionResult CreateSceneta()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateSceneta([FromForm] ScenetaViewModel scenetaViewModel)
        {
            if (scenetaViewModel == null)
            {
                return RedirectToAction("SomethingWentWrong", "Helpers", new { message = "ScenetaViewModel is null" });
            }
            var scenetaDto = new ScenetaDto
            {
                ID = scenetaViewModel.ID,
                Nume = scenetaViewModel.Nume,
                Gen = scenetaViewModel.Gen,
                Durata = scenetaViewModel.Durata
            };
            scenetaService.RegisterSceneta(scenetaDto);
            return View("DetailsSceneta", scenetaViewModel);
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
           var scenetaDto = scenetaService.GetById(id);

            var scenetaViewModel = new ScenetaViewModel
            {
                ID = scenetaDto.ID,
                Nume = scenetaDto.Nume,
                Gen = scenetaDto.Gen,
                Durata = scenetaDto.Durata
            };
            return View("UpdateSceneta", scenetaViewModel);
        }
        [HttpPost]
        public IActionResult Update([FromForm] ScenetaViewModel scenetaViewModel)
        {
            if(scenetaViewModel == null)
            {
                throw new ArgumentNullException(nameof(scenetaViewModel));
            }
            var scenetaDto = new ScenetaDto
            {   ID = scenetaViewModel.ID,
                Nume = scenetaViewModel.Nume,
                Gen= scenetaViewModel.Gen,
                Durata = scenetaViewModel.Durata
            };
            scenetaService.UpdateSceneta(scenetaDto);
            return View("DetailsSceneta", scenetaViewModel);
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
           var scenetaDto = scenetaService.GetById(id);
           scenetaService.DeleteSceneta(scenetaDto);

           return RedirectToAction("AllScenete");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var scenetaDto = scenetaService.Details(id);
            if (scenetaDto == null)
            {
                throw new Exception("Sceneta nu a fost gasita!");
            }
            var scenetaViewModel = new ScenetaViewModel
            {
                ID = scenetaDto.ID,
                Nume = scenetaDto.Nume,
                Gen = scenetaDto.Gen,
                Durata = scenetaDto.Durata
            };
            return View("DetailsSceneta", scenetaViewModel);
        }
    }
}
