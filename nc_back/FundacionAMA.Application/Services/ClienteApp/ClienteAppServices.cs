using FundacionAMA.Domain.DTO.Cliente.Dto;
using FundacionAMA.Domain.DTO.Cliente.FilterDto;
using FundacionAMA.Domain.DTO.Cliente.Request;
using FundacionAMA.Domain.Entities;
using FundacionAMA.Domain.Interfaces.Repositories;
using FundacionAMA.Domain.Shared.Entities.Operation;
using FundacionAMA.Domain.Shared.Extensions.Bussines;
using FundacionAMA.Domain.Shared.Interfaces.Operations;

using Microsoft.EntityFrameworkCore;

using System.Linq.Expressions;

namespace FundacionAMA.Application.Services.ClienteApp
{
    internal class ClienteAppService : IClienteAppService
    {
        private readonly IClienteRepository _clienteRepository;
        //private readonly IDonorRepository _donorRepository;
        //private readonly IVolunteerRepository _volunteerRepository;

        public ClienteAppService(IClienteRepository clienteRepository/*, IDonorRepository donorRepository, IVolunteerRepository volunteerRepository*/)
        {
            _clienteRepository = clienteRepository;
            //_donorRepository = donorRepository;
            //_volunteerRepository = volunteerRepository;
        }

        public async Task<IOperationResult> Create(IOperationRequest<ClienteRequest> entity)
        {
            try
            {
                if (await IsExitByIdentification(entity))
                {
                    return new OperationResult(System.Net.HttpStatusCode.BadRequest, $"la Cliente ya existe");
                    //return new OperationResult(System.Net.HttpStatusCode.BadRequest, $"la Cliente con identificación {entity.Data.Nombre} ya existe");
                }
                //entity.Data.GetNameCompleted();
                Cliente cliente = entity.Data.MapTo<Cliente>();
                
                await _clienteRepository.InsertAsync(cliente);
                await _clienteRepository.SaveChangesAsync(entity);
                return new OperationResult(System.Net.HttpStatusCode.Created, $"la Cliente con identificación pruebano_se_creo_nada se creo correctamente");
            }
            catch (Exception ex)
            {
                return await ex.ToResultAsync();
            }

        }

        private async Task<bool> IsExitByIdentification(IOperationRequest<ClienteRequest> entity)
        {
            return false;//await _clienteRepository.ExistsAscyn(e => e.Active && e.Nombre == entity.Data.Nombre);
        }

        public async Task<IOperationResult> Delete(IOperationRequest<int> id)
        {
            try
            {
                Cliente? cliente = await _clienteRepository.All.Where(e => e.Active && e.Id == id.Data).FirstOrDefaultAsync();
                if (cliente == null)
                {
                    return new OperationResult(System.Net.HttpStatusCode.NotFound, $"la Cliente con id {id.Data} no existe");
                }
                await _clienteRepository.DeleteAsync(cliente);
                await _clienteRepository.SaveChangesAsync(id);
                return new OperationResult(System.Net.HttpStatusCode.OK, $"la cliente con id {id.Data} se elimino correctamente");

            }
            catch (Exception ex)
            {
                return await ex.ToResultAsync();
            }
        }

        public Task<IOperationResultList<ClienteDto>> GetAll(ClienteFilter filter)
        {
            Task<IOperationResultList<ClienteDto>> cliente = _clienteRepository.All
                .Where(GetFilters(filter))

                .ToResultListAsync<Cliente, ClienteDto>(Offset: filter.Offset, Take: filter.Take);

            return cliente;
        }

        private static Expression<Func<Cliente, bool>> GetFilters(ClienteFilter filter)
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

        public async Task<IOperationResult<ClienteDto>> GetById(int id)
        {
            Cliente? cliente = await _clienteRepository.All.Where(e => e.Active && e.Id == id).FirstOrDefaultAsync();
            return cliente == null
                ? new OperationResult<ClienteDto>(System.Net.HttpStatusCode.NotFound, $"la cliente con id {id} no existe")
                : await cliente.ToResultAsync<Cliente, ClienteDto>();
        }

        public async Task<IOperationResult> Update(int id, IOperationRequest<ClienteRequest> entity)
        {
            try
            {
                Cliente? cliente = await _clienteRepository.All
                    //.Include(e => e.IdNavigation)
                    .Where(e => e.Active && e.Id == id).FirstOrDefaultAsync();
                if (cliente == null)
                {
                    return new OperationResult(System.Net.HttpStatusCode.NotFound, $"la cliente con id {id} no existe");
                }
                /*if (await _clienteRepository.ExistsAscyn(e => e.Active && e.Id != id && e.Identification == entity.Data.Identification))
                {
                    return new OperationResult(System.Net.HttpStatusCode.BadRequest, $"la cliente con identificación {entity.Data.Identification} ya existe");
                }
                entity.Data.GetNameCompleted();*/

                cliente = entity.Data.MapTo<Cliente>(cliente, entity.Data);
                /*if (cliente.Donor)
                {
                    if (cliente.IdNavigation == null)
                    {
                        await _donorRepository.InsertAsync(new Donor()
                        {
                            Active = true,
                            ClienteId = cliente.Id,
                            Status = "A"
                        });

                    }
                    else
                    {
                        cliente.IdNavigation.Active = true;
                        cliente.IdNavigation.ClienteId = cliente.Id;
                        cliente.IdNavigation.Status = "A";
                    }

                }
                else
                {
                    if (cliente.IdNavigation != null)
                    {
                        cliente.IdNavigation.Active = false;
                    }

                }


                if (cliente.Volunteer)
                {

                    if (cliente.VolunteerNavigation == null)
                    {

                        if (entity.Data.volunaterRequest == null)
                        {
                            return new OperationResult(System.Net.HttpStatusCode.BadRequest,
                                $"Se debe proporcionar datos si es voluntario");
                        }
                        entity.Data.volunaterRequest.MapTo<Volunteer>();
                        Volunteer volunet = entity.Data.volunaterRequest.MapTo<Volunteer>();
                        volunet.ClienteId = cliente.Id;
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
                        volunterEntity.ClienteId = cliente.Id;
                        cliente.VolunteerNavigation = volunterEntity;
                    }

                }
                else
                {
                    if (cliente.VolunteerNavigation != null)
                    {
                        cliente.VolunteerNavigation.Active = false;
                    }

                }

                if (cliente.Beneficiary != null)
                {
                    cliente.Beneficiary.ClienteId = cliente.Id;


                }*/
                await _clienteRepository.UpdateAsync(cliente);
                await _clienteRepository.SaveChangesAsync(entity);
                return new OperationResult(System.Net.HttpStatusCode.OK, $"la cliente con id {id} se actualizo correctamente");
            }
            catch (Exception ex)
            {
                return await ex.ToResultAsync();
            }
        }
    }
}
