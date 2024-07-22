using FundacionAMA.Domain.DTO.GrupoCliente.Dto;
using FundacionAMA.Domain.DTO.GrupoCliente.FilterDto;
using FundacionAMA.Domain.DTO.GrupoCliente.Request;
using FundacionAMA.Domain.Entities;
using FundacionAMA.Domain.Interfaces.Repositories;
using FundacionAMA.Domain.Shared.Entities.Operation;
using FundacionAMA.Domain.Shared.Extensions.Bussines;
using FundacionAMA.Domain.Shared.Interfaces.Operations;

using Microsoft.EntityFrameworkCore;

using System.Linq.Expressions;

namespace FundacionAMA.Application.Services.GrupoClienteApp
{
    internal class GrupoClienteAppService : IGrupoClienteAppService
    {
        private readonly IGrupoClienteRepository _grupoClienteRepository;
        //private readonly IDonorRepository _donorRepository;
        //private readonly IVolunteerRepository _volunteerRepository;

        public GrupoClienteAppService(IGrupoClienteRepository grupoClienteRepository/*, IDonorRepository donorRepository, IVolunteerRepository volunteerRepository*/)
        {
            _grupoClienteRepository = grupoClienteRepository;
            //_donorRepository = donorRepository;
            //_volunteerRepository = volunteerRepository;
        }

        public async Task<IOperationResult> Create(IOperationRequest<GrupoClienteRequest> entity)
        {
            try
            {
                if (await IsExitByIdentification(entity))
                {
                    return new OperationResult(System.Net.HttpStatusCode.BadRequest, $"la GrupoCliente ya existe");
                    //return new OperationResult(System.Net.HttpStatusCode.BadRequest, $"la GrupoCliente con identificación {entity.Data.Nombre} ya existe");
                }
                //entity.Data.GetNameCompleted();
                GrupoCliente grupoCliente = entity.Data.MapTo<GrupoCliente>();
                
                await _grupoClienteRepository.InsertAsync(grupoCliente);
                await _grupoClienteRepository.SaveChangesAsync(entity);
                return new OperationResult(System.Net.HttpStatusCode.Created, $"la GrupoCliente con identificación pruebano_se_creo_nada se creo correctamente");
            }
            catch (Exception ex)
            {
                return await ex.ToResultAsync();
            }

        }

        private async Task<bool> IsExitByIdentification(IOperationRequest<GrupoClienteRequest> entity)
        {
            return false;//await _grupoClienteRepository.ExistsAscyn(e => e.Active && e.Nombre == entity.Data.Nombre);
        }

        public async Task<IOperationResult> Delete(IOperationRequest<int> id)
        {
            try
            {
                GrupoCliente? grupoCliente = await _grupoClienteRepository.All.Where(e => e.Active && e.Id == id.Data).FirstOrDefaultAsync();
                if (grupoCliente == null)
                {
                    return new OperationResult(System.Net.HttpStatusCode.NotFound, $"la GrupoCliente con id {id.Data} no existe");
                }
                await _grupoClienteRepository.DeleteAsync(grupoCliente);
                await _grupoClienteRepository.SaveChangesAsync(id);
                return new OperationResult(System.Net.HttpStatusCode.OK, $"la grupoCliente con id {id.Data} se elimino correctamente");

            }
            catch (Exception ex)
            {
                return await ex.ToResultAsync();
            }
        }

        public Task<IOperationResultList<GrupoClienteDto>> GetAll(GrupoClienteFilter filter)
        {
            Task<IOperationResultList<GrupoClienteDto>> grupoCliente = _grupoClienteRepository.All
                .Where(GetFilters(filter))

                .ToResultListAsync<GrupoCliente, GrupoClienteDto>(Offset: filter.Offset, Take: filter.Take);

            return grupoCliente;
        }

        private static Expression<Func<GrupoCliente, bool>> GetFilters(GrupoClienteFilter filter)
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

        public async Task<IOperationResult<GrupoClienteDto>> GetById(int id)
        {
            GrupoCliente? grupoCliente = await _grupoClienteRepository.All.Where(e => e.Active && e.Id == id).FirstOrDefaultAsync();
            return grupoCliente == null
                ? new OperationResult<GrupoClienteDto>(System.Net.HttpStatusCode.NotFound, $"la grupoCliente con id {id} no existe")
                : await grupoCliente.ToResultAsync<GrupoCliente, GrupoClienteDto>();
        }

        public async Task<IOperationResult> Update(int id, IOperationRequest<GrupoClienteRequest> entity)
        {
            try
            {
                GrupoCliente? grupoCliente = await _grupoClienteRepository.All
                    //.Include(e => e.IdNavigation)
                    .Where(e => e.Active && e.Id == id).FirstOrDefaultAsync();
                if (grupoCliente == null)
                {
                    return new OperationResult(System.Net.HttpStatusCode.NotFound, $"la grupoCliente con id {id} no existe");
                }
                /*if (await _grupoClienteRepository.ExistsAscyn(e => e.Active && e.Id != id && e.Identification == entity.Data.Identification))
                {
                    return new OperationResult(System.Net.HttpStatusCode.BadRequest, $"la grupoCliente con identificación {entity.Data.Identification} ya existe");
                }
                entity.Data.GetNameCompleted();*/

                grupoCliente = entity.Data.MapTo<GrupoCliente>(grupoCliente, entity.Data);
                /*if (grupoCliente.Donor)
                {
                    if (grupoCliente.IdNavigation == null)
                    {
                        await _donorRepository.InsertAsync(new Donor()
                        {
                            Active = true,
                            GrupoClienteId = grupoCliente.Id,
                            Status = "A"
                        });

                    }
                    else
                    {
                        grupoCliente.IdNavigation.Active = true;
                        grupoCliente.IdNavigation.GrupoClienteId = grupoCliente.Id;
                        grupoCliente.IdNavigation.Status = "A";
                    }

                }
                else
                {
                    if (grupoCliente.IdNavigation != null)
                    {
                        grupoCliente.IdNavigation.Active = false;
                    }

                }


                if (grupoCliente.Volunteer)
                {

                    if (grupoCliente.VolunteerNavigation == null)
                    {

                        if (entity.Data.volunaterRequest == null)
                        {
                            return new OperationResult(System.Net.HttpStatusCode.BadRequest,
                                $"Se debe proporcionar datos si es voluntario");
                        }
                        entity.Data.volunaterRequest.MapTo<Volunteer>();
                        Volunteer volunet = entity.Data.volunaterRequest.MapTo<Volunteer>();
                        volunet.GrupoClienteId = grupoCliente.Id;
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
                        volunterEntity.GrupoClienteId = grupoCliente.Id;
                        grupoCliente.VolunteerNavigation = volunterEntity;
                    }

                }
                else
                {
                    if (grupoCliente.VolunteerNavigation != null)
                    {
                        grupoCliente.VolunteerNavigation.Active = false;
                    }

                }

                if (grupoCliente.Beneficiary != null)
                {
                    grupoCliente.Beneficiary.GrupoClienteId = grupoCliente.Id;


                }*/
                await _grupoClienteRepository.UpdateAsync(grupoCliente);
                await _grupoClienteRepository.SaveChangesAsync(entity);
                return new OperationResult(System.Net.HttpStatusCode.OK, $"la grupoCliente con id {id} se actualizo correctamente");
            }
            catch (Exception ex)
            {
                return await ex.ToResultAsync();
            }
        }
    }
}
