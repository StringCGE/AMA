using FundacionAMA.Domain.Entities;
using FundacionAMA.Domain.Interfaces.Repositories;

namespace FundacionAMA.Infrastructure.Persistence.Repository.GrupoClienteConfiguration
{
    public class GrupoClienteRespository : BaseRepository<GrupoCliente>, IGrupoClienteRepository
    {
        public GrupoClienteRespository(FundacionAMADbContext context) : base(context)
        {
        }
    }
}