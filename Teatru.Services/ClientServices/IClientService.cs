

using Teatru.Services.ClientServices.Dto;

namespace Teatru.Services.ClientServices
{
    public interface IClientService
    {
        List<ClientDto> GetAllClienti();
        bool GetByEmail(string email);
        void RegisterClient(ClientDto clientDto);
        ClientDto SearchByEmail(string email);
    }
}
