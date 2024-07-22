using FundacionAMA.Domain.DTO.Grupo.Dto;
using FundacionAMA.Domain.DTO.Grupo.FilterDto;
using FundacionAMA.Domain.DTO.Grupo.Request;
using FundacionAMA.Domain.Interfaces.Services;
using FundacionAMA.Domain.Shared.Interfaces.Operations;

namespace FundacionAMA.Application.Services.GrupoApp
{
    public interface IGrupoAppService : ICrudService<IOperationRequest<GrupoRequest>, GrupoDto, GrupoFilter, int>
    {

    }
}