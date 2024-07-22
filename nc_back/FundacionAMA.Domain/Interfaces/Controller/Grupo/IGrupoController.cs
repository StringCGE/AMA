using FundacionAMA.Domain.DTO.Grupo.FilterDto;
using FundacionAMA.Domain.DTO.Grupo.Request;

namespace FundacionAMA.Domain.Interfaces.Controller.Grupo
{
    public interface IGrupoController : ICrudController<GrupoRequest, GrupoFilter, int>
    {
    }
}