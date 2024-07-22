using FundacionAMA.Domain.DTO.Grupo.Dto;
using FundacionAMA.Domain.DTO.Grupo.FilterDto;
using FundacionAMA.Domain.DTO.Grupo.Request;

namespace FundacionAMA.Domain.Interfaces.Services
{
    /// <summary>
    /// servicio de Grupo
    /// </summary>
    public interface IGrupoService : ICrudService<IOperationRequest<GrupoRequest>, GrupoDto, GrupoFilter, int>
    {
    }
}