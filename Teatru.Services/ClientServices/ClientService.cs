

using Teatru.Data;
using Teatru.Data.Entities;
using Teatru.Services.ClientServices.Dto;

namespace Teatru.Services.ClientServices
{
    public class ClientService : IClientService
    {
        private readonly IRepository<Client> repositoryClient;
        private readonly IUnitOfWork unitOfWork;
        public ClientService(IRepository<Client> repositoryClient, IUnitOfWork unitOfWork)
        {
            this.repositoryClient = repositoryClient;      
            this.unitOfWork = unitOfWork;
        }

        public List<ClientDto> GetAllClienti()
        {
          var clientiDto = repositoryClient.GetAll().Select(x => new ClientDto
            {
                ID = x.ID,
                Prenume = x.Prenume,
                Nume = x.Nume,
                Email = x.Email,
                Telefon = x.Telefon
            }).ToList();
            return clientiDto;
        }

        public void RegisterClient(ClientDto clientDto)
        {
            if (clientDto == null)
            {
                throw new ArgumentNullException(nameof(clientDto));
            }
            if(repositoryClient.Query(c => c.Email == clientDto.Email).Any())
            {
                return ;
            }
            var client = new Client
            {
                Prenume = clientDto.Prenume,  
                Nume = clientDto.Nume,
                Email = clientDto.Email,
                Telefon = clientDto.Telefon
            };
            repositoryClient.Add(client);
            unitOfWork.SaveChanges();
        }

        public bool GetByEmail(string email)
        {
            if(repositoryClient.Query(c => c.Email == email).Any())
            {
                return true;
            }
            return false;

        }

        public ClientDto SearchByEmail(string email)
        {
            var clientDto = repositoryClient.Query(c => c.Email == email).FirstOrDefault();

            if(clientDto == null)
            {
                throw new NullReferenceException(nameof(clientDto));
            }

            return new ClientDto
            {
                ID = clientDto.ID,
                Prenume = clientDto.Prenume,
                Nume = clientDto.Nume,
                Email=clientDto.Email,
                Telefon= clientDto.Telefon
            };
       
        }

        
    }
}
