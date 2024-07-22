using FundacionAMA.Domain.DTO.GrupoCliente.Dto;
using FundacionAMA.Domain.DTO.GrupoCliente.FilterDto;
using FundacionAMA.Domain.DTO.GrupoCliente.Request;

namespace FundacionAMA.Domain.Interfaces.Services
{
    /// <summary>
    /// servicio de GrupoCliente
    /// </summary>
    public interface IGrupoClienteService : ICrudService<IOperationRequest<GrupoClienteRequest>, GrupoClienteDto, GrupoClienteFilter, int>
    {
    }
}