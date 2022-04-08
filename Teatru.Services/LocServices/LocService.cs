
using Teatru.Data;
using Teatru.Data.Entities;
using Teatru.Services.LocServices.Dto;

namespace Teatru.Services.LocServices
{
    public class LocService : ILocService
    {
        private readonly IRepository<Loc> repositoryLoc;
        public LocService(IRepository<Loc> repositoryLoc)
        {
            this.repositoryLoc = repositoryLoc;
        }

        public List<LocDto> GetAll()
        {
            var locuri = repositoryLoc.GetAll();
            return locuri.Select(x => new LocDto
            {
                ID = x.ID,
                Rand = x.Rand,
                NumarLoc = x.NumarLoc        
            }).ToList();
        }

    }
}
