using FundacionAMA.Domain.Entities;
using FundacionAMA.Domain.Interfaces.Repositories;

namespace FundacionAMA.Infrastructure.Persistence.Repository.GrupoConfiguration
{
    public class GrupoRespository : BaseRepository<Grupo>, IGrupoRepository
    {
        public GrupoRespository(FundacionAMADbContext context) : base(context)
        {
        }
    }
}