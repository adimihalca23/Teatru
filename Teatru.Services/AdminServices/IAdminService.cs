

using Teatru.Services.ActorServices;
using Teatru.Services.RezervareServices.Dto;
using Teatru.Services.ScenetaServices.Dto;

namespace Teatru.Services.AdminServices
{
    public interface IAdminService
    {
        List<ScenetaDto> GetAllScenete();
        ScenetaDto GetSceneteById(int id);
        void RegisterSceneta(ScenetaDto scenetaDto);
        void UpdateSceneta(ScenetaDto scenetaDto);
        void DeleteSceneta(ScenetaDto scenetaDto);
        List<ActorDto> GetAllActori();
        ActorDto GetActorById(int id);
        void RegisterActor(ActorDto actorDto); 
        void UpdateActor(ActorDto actorDto);
        void DeleteActor(ActorDto actorDto);
        List<RezervareDto> GetRezervari();
        
    }
}
