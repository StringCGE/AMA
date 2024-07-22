using FundacionAMA.Domain.DTO.Person.Dto;
//using FundacionAMA.Domain.DTO.Person.Filter;
using FundacionAMA.Domain.DTO.Person.FilterDto;
using FundacionAMA.Domain.DTO.Person.Request;

namespace FundacionAMA.Domain.Services
{
    internal class PersonService : IPersonService
    {
        public readonly IPersonRepository _repository;

        public PersonService(IPersonRepository repository)
        {
            _repository = repository;
        }

        public async Task<IOperationResult> Create(IOperationRequest<PersonRequest> entity)
        {
            try
            {
                //entity.Data.GetTotal();
                Person donacionEntiy = entity.Data.MapTo<Person>();
                await _repository.InsertAsync(donacionEntiy);
                await _repository.SaveChangesAsync();
                return new OperationResult(System.Net.HttpStatusCode.Created, "Person creado con éxito");

            }
            catch (Exception ex)
            {
                return await ex.ToResultAsync();
            }
        }

        public async Task<IOperationResult> Delete(IOperationRequest<int> id)
        {
            try
            {
                Person? entidad = await _repository.All.FirstOrDefaultAsync(e => e.Active && e.Id == id.Data);

                if (entidad == null)
                {
                    return new OperationResult(System.Net.HttpStatusCode.NotFound, "Person no encontrado");
                }

                await _repository.DeleteAsync(entidad);
                await _repository.SaveChangesAsync();
                return new OperationResult(System.Net.HttpStatusCode.NoContent, "Person eliminado con éxito");
            }
            catch (Exception ex)
            {
                return await ex.ToResultAsync();
            }
        }

        public async Task<IOperationResultList<PersonDto>> GetAll(PersonFilter filter)
        {
            try
            {
                IOperationResultList<PersonDto> entidad = await _repository

                    .All
                    //.Include(e => e.PersonType)
                    .Where(
                    e => e.Active
                    /*&& (string.IsNullOrWhiteSpace(filter.Name) || e.Name.Contains(filter.Name))

                    && (filter.PersonId == null || e.PersonId == filter.PersonId)
                    && (filter.Id == null || e.Id == filter.Id)
                    && (filter.BrigadeId == null || e.PersonId == filter.BrigadeId)
                    && (filter.PersonTypeId == null || e.PersonTypeId == filter.PersonTypeId)
                    */
                    )
                    .ToResultListAsync<Person, PersonDto>(Offset: filter.Offset, Take: filter.Take);

                return entidad;

            }
            catch (Exception ex)
            {
                return await ex.ToResultListAsync<PersonDto>();
            }
        }

        public async Task<IOperationResult<PersonDto>> GetById(int id)
        {
            try
            {
                Person? entidad = await _repository.All.FirstOrDefaultAsync(e => e.Active && e.Id == id);
                return entidad == null
                    ? new OperationResult<PersonDto>(System.Net.HttpStatusCode.NotFound, "Person no encontrado")
                    : await entidad.ToResultAsync<Person, PersonDto>();
            }
            catch (Exception ex)
            {
                return await ex.ToResultAsync<PersonDto>();
            }
        }

        public async Task<IOperationResult> Update(int id, IOperationRequest<PersonRequest> entity)
        {
            try
            {
                //entity.Data.GetTotal();

                Person? entidad = await _repository.All.FirstOrDefaultAsync(e => e.Active && e.Id == id);
                if (entidad == null)
                {
                    return new OperationResult(System.Net.HttpStatusCode.NotFound, "Person no encontrado");
                }

                entidad = entidad.MapTo<Person>(entity.Data);

                await _repository.UpdateAsync(entidad);
                await _repository.SaveChangesAsync();
                return new OperationResult(System.Net.HttpStatusCode.NoContent, "Person actualizado con éxito");

            }
            catch (Exception ex)
            {
                return await ex.ToResultAsync();
            }

        }
    }
}