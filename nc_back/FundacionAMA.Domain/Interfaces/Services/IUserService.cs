using FundacionAMA.Domain.DTO.User.Dto;
using FundacionAMA.Domain.DTO.User.FilterDto;
using FundacionAMA.Domain.DTO.User.Request;

namespace FundacionAMA.Domain.Interfaces.Services
{
    /// <summary>
    /// servicio de User
    /// </summary>
    public interface IUserService : ICrudService<IOperationRequest<UserRequest>, UserDto, UserFilter, int>
    {
    }
}