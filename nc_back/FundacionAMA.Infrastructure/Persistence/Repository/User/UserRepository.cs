using FundacionAMA.Domain.Entities;
using FundacionAMA.Domain.Interfaces.Repositories;

namespace FundacionAMA.Infrastructure.Persistence.Repository.UserConfiguration
{
    public class UserRespository : BaseRepository<User>, IUserRepository
    {
        public UserRespository(FundacionAMADbContext context) : base(context)
        {
        }
    }
}