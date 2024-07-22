using FundacionAMA.Domain.DTO.Grupo.Dto;
using FundacionAMA.Domain.DTO.Grupo.FilterDto;
using FundacionAMA.Domain.DTO.Grupo.Request;
using FundacionAMA.Domain.Entities;
using FundacionAMA.Domain.Interfaces.Repositories;
using FundacionAMA.Domain.Shared.Entities.Operation;
using FundacionAMA.Domain.Shared.Extensions.Bussines;
using FundacionAMA.Domain.Shared.Interfaces.Operations;

using Microsoft.EntityFrameworkCore;

using System.Linq.Expressions;

namespace FundacionAMA.Application.Services.GrupoApp
{
    internal class GrupoAppService : IGrupoAppService
    {
        private readonly IGrupoRepository _grupoRepository;
        //private readonly IDonorRepository _donorRepository;
        //private readonly IVolunteerRepository _volunteerRepository;

        public GrupoAppService(IGrupoRepository grupoRepository/*, IDonorRepository donorRepository, IVolunteerRepository volunteerRepository*/)
        {
            _grupoRepository = grupoRepository;
            //_donorRepository = donorRepository;
            //_volunteerRepository = volunteerRepository;
        }

        public async Task<IOperationResult> Create(IOperationRequest<GrupoRequest> entity)
        {
            try
            {
                if (await IsExitByIdentification(entity))
                {
                    return new OperationResult(System.Net.HttpStatusCode.BadRequest, $"la Grupo ya existe");
                    //return new OperationResult(System.Net.HttpStatusCode.BadRequest, $"la Grupo con identificación {entity.Data.Nombre} ya existe");
                }
                //entity.Data.GetNameCompleted();
                Grupo grupo = entity.Data.MapTo<Grupo>();
                
                await _grupoRepository.InsertAsync(grupo);
                await _grupoRepository.SaveChangesAsync(entity);
                return new OperationResult(System.Net.HttpStatusCode.Created, $"la Grupo con identificación pruebano_se_creo_nada se creo correctamente");
            }
            catch (Exception ex)
            {
                return await ex.ToResultAsync();
            }

        }

        private async Task<bool> IsExitByIdentification(IOperationRequest<GrupoRequest> entity)
        {
            return false;//await _grupoRepository.ExistsAscyn(e => e.Active && e.Nombre == entity.Data.Nombre);
        }

        public async Task<IOperationResult> Delete(IOperationRequest<int> id)
        {
            try
            {
                Grupo? grupo = await _grupoRepository.All.Where(e => e.Active && e.Id == id.Data).FirstOrDefaultAsync();
                if (grupo == null)
                {
                    return new OperationResult(System.Net.HttpStatusCode.NotFound, $"la Grupo con id {id.Data} no existe");
                }
                await _grupoRepository.DeleteAsync(grupo);
                await _grupoRepository.SaveChangesAsync(id);
                return new OperationResult(System.Net.HttpStatusCode.OK, $"la grupo con id {id.Data} se elimino correctamente");

            }
            catch (Exception ex)
            {
                return await ex.ToResultAsync();
            }
        }

        public Task<IOperationResultList<GrupoDto>> GetAll(GrupoFilter filter)
        {
            Task<IOperationResultList<GrupoDto>> grupo = _grupoRepository.All
                .Where(GetFilters(filter))

                .ToResultListAsync<Grupo, GrupoDto>(Offset: filter.Offset, Take: filter.Take);

            return grupo;
        }

        private static Expression<Func<Grupo, bool>> GetFilters(GrupoFilter filter)
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

        public async Task<IOperationResult<GrupoDto>> GetById(int id)
        {
            Grupo? grupo = await _grupoRepository.All.Where(e => e.Active && e.Id == id).FirstOrDefaultAsync();
            return grupo == null
                ? new OperationResult<GrupoDto>(System.Net.HttpStatusCode.NotFound, $"la grupo con id {id} no existe")
                : await grupo.ToResultAsync<Grupo, GrupoDto>();
        }

        public async Task<IOperationResult> Update(int id, IOperationRequest<GrupoRequest> entity)
        {
            try
            {
                Grupo? grupo = await _grupoRepository.All
                    //.Include(e => e.IdNavigation)
                    .Where(e => e.Active && e.Id == id).FirstOrDefaultAsync();
                if (grupo == null)
                {
                    return new OperationResult(System.Net.HttpStatusCode.NotFound, $"la grupo con id {id} no existe");
                }
                /*if (await _grupoRepository.ExistsAscyn(e => e.Active && e.Id != id && e.Identification == entity.Data.Identification))
                {
                    return new OperationResult(System.Net.HttpStatusCode.BadRequest, $"la grupo con identificación {entity.Data.Identification} ya existe");
                }
                entity.Data.GetNameCompleted();*/

                grupo = entity.Data.MapTo<Grupo>(grupo, entity.Data);
                /*if (grupo.Donor)
                {
                    if (grupo.IdNavigation == null)
                    {
                        await _donorRepository.InsertAsync(new Donor()
                        {
                            Active = true,
                            GrupoId = grupo.Id,
                            Status = "A"
                        });

                    }
                    else
                    {
                        grupo.IdNavigation.Active = true;
                        grupo.IdNavigation.GrupoId = grupo.Id;
                        grupo.IdNavigation.Status = "A";
                    }

                }
                else
                {
                    if (grupo.IdNavigation != null)
                    {
                        grupo.IdNavigation.Active = false;
                    }

                }


                if (grupo.Volunteer)
                {

                    if (grupo.VolunteerNavigation == null)
                    {

                        if (entity.Data.volunaterRequest == null)
                        {
                            return new OperationResult(System.Net.HttpStatusCode.BadRequest,
                                $"Se debe proporcionar datos si es voluntario");
                        }
                        entity.Data.volunaterRequest.MapTo<Volunteer>();
                        Volunteer volunet = entity.Data.volunaterRequest.MapTo<Volunteer>();
                        volunet.GrupoId = grupo.Id;
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
                        volunterEntity.GrupoId = grupo.Id;
                        grupo.VolunteerNavigation = volunterEntity;
                    }

                }
                else
                {
                    if (grupo.VolunteerNavigation != null)
                    {
                        grupo.VolunteerNavigation.Active = false;
                    }

                }

                if (grupo.Beneficiary != null)
                {
                    grupo.Beneficiary.GrupoId = grupo.Id;


                }*/
                await _grupoRepository.UpdateAsync(grupo);
                await _grupoRepository.SaveChangesAsync(entity);
                return new OperationResult(System.Net.HttpStatusCode.OK, $"la grupo con id {id} se actualizo correctamente");
            }
            catch (Exception ex)
            {
                return await ex.ToResultAsync();
            }
        }
    }
}
