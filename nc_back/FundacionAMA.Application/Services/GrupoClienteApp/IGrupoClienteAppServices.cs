using FundacionAMA.Domain.DTO.GrupoCliente.Dto;
using FundacionAMA.Domain.DTO.GrupoCliente.FilterDto;
using FundacionAMA.Domain.DTO.GrupoCliente.Request;
using FundacionAMA.Domain.Interfaces.Services;
using FundacionAMA.Domain.Shared.Interfaces.Operations;

namespace FundacionAMA.Application.Services.GrupoClienteApp
{
    public interface IGrupoClienteAppService : ICrudService<IOperationRequest<GrupoClienteRequest>, GrupoClienteDto, GrupoClienteFilter, int>
    {

    }
}