using FundacionAMA.Domain.DTO.User.FilterDto;
using FundacionAMA.Domain.DTO.User.Request;

namespace FundacionAMA.Domain.Interfaces.Controller.User
{
    public interface IUserController : ICrudController<UserRequest, UserFilter, int>
    {
    }
}