using FundacionAMA.Domain.DTO.Cliente.FilterDto;
using FundacionAMA.Domain.DTO.Cliente.Request;

namespace FundacionAMA.Domain.Interfaces.Controller.Cliente
{
    public interface IClienteController : ICrudController<ClienteRequest, ClienteFilter, int>
    {
    }
}