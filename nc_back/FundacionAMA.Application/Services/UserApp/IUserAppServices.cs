using FundacionAMA.Domain.DTO.User.Dto;
using FundacionAMA.Domain.DTO.User.FilterDto;
using FundacionAMA.Domain.DTO.User.Request;
using FundacionAMA.Domain.Interfaces.Services;
using FundacionAMA.Domain.Shared.Interfaces.Operations;

namespace FundacionAMA.Application.Services.UserApp
{
    public interface IUserAppService : ICrudService<IOperationRequest<UserRequest>, UserDto, UserFilter, int>
    {

    }
}