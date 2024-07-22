using FundacionAMA.Domain.DTO.Cliente.Dto;
using FundacionAMA.Domain.DTO.Cliente.FilterDto;
using FundacionAMA.Domain.DTO.Cliente.Request;
using FundacionAMA.Domain.Interfaces.Services;
using FundacionAMA.Domain.Shared.Interfaces.Operations;

namespace FundacionAMA.Application.Services.ClienteApp
{
    public interface IClienteAppService : ICrudService<IOperationRequest<ClienteRequest>, ClienteDto, ClienteFilter, int>
    {

    }
}