using FundacionAMA.Domain.DTO.Person.Dto;
using FundacionAMA.Domain.DTO.Person.FilterDto;
using FundacionAMA.Domain.DTO.Person.Request;
using FundacionAMA.Domain.Entities;
using FundacionAMA.Domain.Interfaces.Repositories;
using FundacionAMA.Domain.Shared.Entities.Operation;
using FundacionAMA.Domain.Shared.Extensions.Bussines;
using FundacionAMA.Domain.Shared.Interfaces.Operations;

using Microsoft.EntityFrameworkCore;

using System.Linq.Expressions;

namespace FundacionAMA.Application.Services.PersonApp
{
    internal class PersonAppService : IPersonAppService
    {
        private readonly IPersonRepository _personRepository;
        //private readonly IDonorRepository _donorRepository;
        //private readonly IVolunteerRepository _volunteerRepository;

        public PersonAppService(IPersonRepository personRepository/*, IDonorRepository donorRepository, IVolunteerRepository volunteerRepository*/)
        {
            _personRepository = personRepository;
            //_donorRepository = donorRepository;
            //_volunteerRepository = volunteerRepository;
        }

        public async Task<IOperationResult> Create(IOperationRequest<PersonRequest> entity)
        {
            try
            {
                if (await IsExitByIdentification(entity))
                {
                    return new OperationResult(System.Net.HttpStatusCode.BadRequest, $"la Person ya existe");
                    //return new OperationResult(System.Net.HttpStatusCode.BadRequest, $"la Person con identificación {entity.Data.Nombre} ya existe");
                }
                //entity.Data.GetNameCompleted();
                Person person = entity.Data.MapTo<Person>();
                
                await _personRepository.InsertAsync(person);
                await _personRepository.SaveChangesAsync(entity);
                return new OperationResult(System.Net.HttpStatusCode.Created, $"la Person con identificación pruebano_se_creo_nada se creo correctamente");
            }
            catch (Exception ex)
            {
                return await ex.ToResultAsync();
            }

        }

        private async Task<bool> IsExitByIdentification(IOperationRequest<PersonRequest> entity)
        {
            return false;//await _personRepository.ExistsAscyn(e => e.Active && e.Nombre == entity.Data.Nombre);
        }

        public async Task<IOperationResult> Delete(IOperationRequest<int> id)
        {
            try
            {
                Person? person = await _personRepository.All.Where(e => e.Active && e.Id == id.Data).FirstOrDefaultAsync();
                if (person == null)
                {
                    return new OperationResult(System.Net.HttpStatusCode.NotFound, $"la Person con id {id.Data} no existe");
                }
                await _personRepository.DeleteAsync(person);
                await _personRepository.SaveChangesAsync(id);
                return new OperationResult(System.Net.HttpStatusCode.OK, $"la person con id {id.Data} se elimino correctamente");

            }
            catch (Exception ex)
            {
                return await ex.ToResultAsync();
            }
        }

        public Task<IOperationResultList<PersonDto>> GetAll(PersonFilter filter)
        {
            Task<IOperationResultList<PersonDto>> person = _personRepository.All
                .Where(GetFilters(filter))

                .ToResultListAsync<Person, PersonDto>(Offset: filter.Offset, Take: filter.Take);

            return person;
        }

        private static Expression<Func<Person, bool>> GetFilters(PersonFilter filter)
        {
            return e => e.Active;
            /*return e => e.Active &&
                (!filter.Volunteer.HasValue || e.Volunteer == filter.Volunteer.Value) &&
                (!filter.Donor.HasValue || e.Donor == filter.Donor.Value) &&
                (string.IsNullOrEmpty(filter.Identification) || e.Identification.Contains(filter.Identification)) &&
                (string.IsNullOrEmpty(filter.FirstName) || e.FirstName.Contains(filter.FirstName)) &&
                (string.IsNullOrEmpty(filter.Phone) || e.Phone.Contains(filter.Phone)) &&
                (string.IsNullOrEmpty(filter.LastName) || e.LastName.Contains(filter.LastName)) &&
                (string.IsNullOrEmpty(filter.Name) || e.FirstName.Contains(filter.Name) || e.SecondName.Contains(filter.Name) || e.LastName.Contains(filter.Name) || e.SecondLastName.Contains(filter.Name)) &&
                (string.IsNullOrEmpty(filter.Email) || e.Email.Contains(filter.Email));*/
        }

        public async Task<IOperationResult<PersonDto>> GetById(int id)
        {
            Person? person = await _personRepository.All.Where(e => e.Active && e.Id == id).FirstOrDefaultAsync();
            return person == null
                ? new OperationResult<PersonDto>(System.Net.HttpStatusCode.NotFound, $"la person con id {id} no existe")
                : await person.ToResultAsync<Person, PersonDto>();
        }

        public async Task<IOperationResult> Update(int id, IOperationRequest<PersonRequest> entity)
        {
            try
            {
                Person? person = await _personRepository.All
                    //.Include(e => e.IdNavigation)
                    .Where(e => e.Active && e.Id == id).FirstOrDefaultAsync();
                if (person == null)
                {
                    return new OperationResult(System.Net.HttpStatusCode.NotFound, $"la person con id {id} no existe");
                }
                /*if (await _personRepository.ExistsAscyn(e => e.Active && e.Id != id && e.Identification == entity.Data.Identification))
                {
                    return new OperationResult(System.Net.HttpStatusCode.BadRequest, $"la person con identificación {entity.Data.Identification} ya existe");
                }
                entity.Data.GetNameCompleted();*/

                person = entity.Data.MapTo<Person>(person, entity.Data);
                /*if (person.Donor)
                {
                    if (person.IdNavigation == null)
                    {
                        await _donorRepository.InsertAsync(new Donor()
                        {
                            Active = true,
                            PersonId = person.Id,
                            Status = "A"
                        });

                    }
                    else
                    {
                        person.IdNavigation.Active = true;
                        person.IdNavigation.PersonId = person.Id;
                        person.IdNavigation.Status = "A";
                    }

                }
                else
                {
                    if (person.IdNavigation != null)
                    {
                        person.IdNavigation.Active = false;
                    }

                }


                if (person.Volunteer)
                {

                    if (person.VolunteerNavigation == null)
                    {

                        if (entity.Data.volunaterRequest == null)
                        {
                            return new OperationResult(System.Net.HttpStatusCode.BadRequest,
                                $"Se debe proporcionar datos si es voluntario");
                        }
                        entity.Data.volunaterRequest.MapTo<Volunteer>();
                        Volunteer volunet = entity.Data.volunaterRequest.MapTo<Volunteer>();
                        volunet.PersonId = person.Id;
                        await _volunteerRepository.InsertAsync(volunet);
                    }
                    else
                    {
                        if (entity.Data.volunaterRequest == null)
                        {
                            return new OperationResult(System.Net.HttpStatusCode.BadRequest,
                                $"Se debe proporcionar datos si es voluntario");
                        }

                        Volunteer volunterEntity = entity.Data.volunaterRequest.MapTo<Volunteer>();
                        volunterEntity.PersonId = person.Id;
                        person.VolunteerNavigation = volunterEntity;
                    }

                }
                else
                {
                    if (person.VolunteerNavigation != null)
                    {
                        person.VolunteerNavigation.Active = false;
                    }

                }

                if (person.Beneficiary != null)
                {
                    person.Beneficiary.PersonId = person.Id;


                }*/
                await _personRepository.UpdateAsync(person);
                await _personRepository.SaveChangesAsync(entity);
                return new OperationResult(System.Net.HttpStatusCode.OK, $"la person con id {id} se actualizo correctamente");
            }
            catch (Exception ex)
            {
                return await ex.ToResultAsync();
            }
        }
    }
}
