using FundacionAMA.Domain.DTO.Person.Dto;
using FundacionAMA.Domain.DTO.Person.FilterDto;
using FundacionAMA.Domain.DTO.Person.Request;

namespace FundacionAMA.Domain.Interfaces.Services
{
    /// <summary>
    /// servicio de Person
    /// </summary>
    public interface IPersonService : ICrudService<IOperationRequest<PersonRequest>, PersonDto, PersonFilter, int>
    {
    }
}