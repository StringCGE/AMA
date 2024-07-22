using FundacionAMA.Domain.DTO.Cliente.Dto;
//using FundacionAMA.Domain.DTO.Cliente.Filter;
using FundacionAMA.Domain.DTO.Cliente.FilterDto;
using FundacionAMA.Domain.DTO.Cliente.Request;

namespace FundacionAMA.Domain.Services
{
    internal class ClienteService : IClienteService
    {
        public readonly IClienteRepository _repository;

        public ClienteService(IClienteRepository repository)
        {
            _repository = repository;
        }

        public async Task<IOperationResult> Create(IOperationRequest<ClienteRequest> entity)
        {
            try
            {
                //entity.Data.GetTotal();
                Cliente donacionEntiy = entity.Data.MapTo<Cliente>();
                await _repository.InsertAsync(donacionEntiy);
                await _repository.SaveChangesAsync();
                return new OperationResult(System.Net.HttpStatusCode.Created, "Cliente creado con éxito");

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
                Cliente? entidad = await _repository.All.FirstOrDefaultAsync(e => e.Active && e.Id == id.Data);

                if (entidad == null)
                {
                    return new OperationResult(System.Net.HttpStatusCode.NotFound, "Cliente no encontrado");
                }

                await _repository.DeleteAsync(entidad);
                await _repository.SaveChangesAsync();
                return new OperationResult(System.Net.HttpStatusCode.NoContent, "Cliente eliminado con éxito");
            }
            catch (Exception ex)
            {
                return await ex.ToResultAsync();
            }
        }

        public async Task<IOperationResultList<ClienteDto>> GetAll(ClienteFilter filter)
        {
            try
            {
                IOperationResultList<ClienteDto> entidad = await _repository

                    .All
                    //.Include(e => e.ClienteType)
                    .Where(
                    e => e.Active
                    /*&& (string.IsNullOrWhiteSpace(filter.Name) || e.Name.Contains(filter.Name))

                    && (filter.PersonId == null || e.PersonId == filter.PersonId)
                    && (filter.Id == null || e.Id == filter.Id)
                    && (filter.BrigadeId == null || e.PersonId == filter.BrigadeId)
                    && (filter.ClienteTypeId == null || e.ClienteTypeId == filter.ClienteTypeId)
                    */
                    )
                    .ToResultListAsync<Cliente, ClienteDto>(Offset: filter.Offset, Take: filter.Take);

                return entidad;

            }
            catch (Exception ex)
            {
                return await ex.ToResultListAsync<ClienteDto>();
            }
        }

        public async Task<IOperationResult<ClienteDto>> GetById(int id)
        {
            try
            {
                Cliente? entidad = await _repository.All.FirstOrDefaultAsync(e => e.Active && e.Id == id);
                return entidad == null
                    ? new OperationResult<ClienteDto>(System.Net.HttpStatusCode.NotFound, "Cliente no encontrado")
                    : await entidad.ToResultAsync<Cliente, ClienteDto>();
            }
            catch (Exception ex)
            {
                return await ex.ToResultAsync<ClienteDto>();
            }
        }

        public async Task<IOperationResult> Update(int id, IOperationRequest<ClienteRequest> entity)
        {
            try
            {
                //entity.Data.GetTotal();

                Cliente? entidad = await _repository.All.FirstOrDefaultAsync(e => e.Active && e.Id == id);
                if (entidad == null)
                {
                    return new OperationResult(System.Net.HttpStatusCode.NotFound, "Cliente no encontrado");
                }

                entidad = entidad.MapTo<Cliente>(entity.Data);

                await _repository.UpdateAsync(entidad);
                await _repository.SaveChangesAsync();
                return new OperationResult(System.Net.HttpStatusCode.NoContent, "Cliente actualizado con éxito");

            }
            catch (Exception ex)
            {
                return await ex.ToResultAsync();
            }

        }
    }
}