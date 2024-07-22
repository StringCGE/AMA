using FundacionAMA.Domain.DTO.Cliente.Dto;
using FundacionAMA.Domain.DTO.Cliente.FilterDto;
using FundacionAMA.Domain.DTO.Cliente.Request;

namespace FundacionAMA.Domain.Interfaces.Services
{
    /// <summary>
    /// servicio de Cliente
    /// </summary>
    public interface IClienteService : ICrudService<IOperationRequest<ClienteRequest>, ClienteDto, ClienteFilter, int>
    {
    }
}