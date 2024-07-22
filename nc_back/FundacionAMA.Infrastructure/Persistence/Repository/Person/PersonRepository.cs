using FundacionAMA.Domain.Entities;
using FundacionAMA.Domain.Interfaces.Repositories;

namespace FundacionAMA.Infrastructure.Persistence.Repository.PersonConfiguration
{
    public class PersonRespository : BaseRepository<Person>, IPersonRepository
    {
        public PersonRespository(FundacionAMADbContext context) : base(context)
        {
        }
    }
}