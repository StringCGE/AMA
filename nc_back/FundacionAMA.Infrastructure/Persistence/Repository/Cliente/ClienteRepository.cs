using FundacionAMA.Domain.Entities;
using FundacionAMA.Domain.Interfaces.Repositories;

namespace FundacionAMA.Infrastructure.Persistence.Repository.ClienteConfiguration
{
    public class ClienteRespository : BaseRepository<Cliente>, IClienteRepository
    {
        public ClienteRespository(FundacionAMADbContext context) : base(context)
        {
        }
    }
}