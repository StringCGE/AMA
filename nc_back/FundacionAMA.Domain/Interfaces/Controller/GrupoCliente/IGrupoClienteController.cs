using FundacionAMA.Domain.DTO.GrupoCliente.FilterDto;
using FundacionAMA.Domain.DTO.GrupoCliente.Request;

namespace FundacionAMA.Domain.Interfaces.Controller.GrupoCliente
{
    public interface IGrupoClienteController : ICrudController<GrupoClienteRequest, GrupoClienteFilter, int>
    {
    }
}