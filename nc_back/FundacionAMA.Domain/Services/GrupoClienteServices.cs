using FundacionAMA.Domain.DTO.GrupoCliente.Dto;
//using FundacionAMA.Domain.DTO.GrupoCliente.Filter;
using FundacionAMA.Domain.DTO.GrupoCliente.FilterDto;
using FundacionAMA.Domain.DTO.GrupoCliente.Request;

namespace FundacionAMA.Domain.Services
{
    internal class GrupoClienteService : IGrupoClienteService
    {
        public readonly IGrupoClienteRepository _repository;

        public GrupoClienteService(IGrupoClienteRepository repository)
        {
            _repository = repository;
        }

        public async Task<IOperationResult> Create(IOperationRequest<GrupoClienteRequest> entity)
        {
            try
            {
                //entity.Data.GetTotal();
                GrupoCliente donacionEntiy = entity.Data.MapTo<GrupoCliente>();
                await _repository.InsertAsync(donacionEntiy);
                await _repository.SaveChangesAsync();
                return new OperationResult(System.Net.HttpStatusCode.Created, "GrupoCliente creado con éxito");

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
                GrupoCliente? entidad = await _repository.All.FirstOrDefaultAsync(e => e.Active && e.Id == id.Data);

                if (entidad == null)
                {
                    return new OperationResult(System.Net.HttpStatusCode.NotFound, "GrupoCliente no encontrado");
                }

                await _repository.DeleteAsync(entidad);
                await _repository.SaveChangesAsync();
                return new OperationResult(System.Net.HttpStatusCode.NoContent, "GrupoCliente eliminado con éxito");
            }
            catch (Exception ex)
            {
                return await ex.ToResultAsync();
            }
        }

        public async Task<IOperationResultList<GrupoClienteDto>> GetAll(GrupoClienteFilter filter)
        {
            try
            {
                IOperationResultList<GrupoClienteDto> entidad = await _repository

                    .All
                    //.Include(e => e.GrupoClienteType)
                    .Where(
                    e => e.Active
                    /*&& (string.IsNullOrWhiteSpace(filter.Name) || e.Name.Contains(filter.Name))

                    && (filter.PersonId == null || e.PersonId == filter.PersonId)
                    && (filter.Id == null || e.Id == filter.Id)
                    && (filter.BrigadeId == null || e.PersonId == filter.BrigadeId)
                    && (filter.GrupoClienteTypeId == null || e.GrupoClienteTypeId == filter.GrupoClienteTypeId)
                    */
                    )
                    .ToResultListAsync<GrupoCliente, GrupoClienteDto>(Offset: filter.Offset, Take: filter.Take);

                return entidad;

            }
            catch (Exception ex)
            {
                return await ex.ToResultListAsync<GrupoClienteDto>();
            }
        }

        public async Task<IOperationResult<GrupoClienteDto>> GetById(int id)
        {
            try
            {
                GrupoCliente? entidad = await _repository.All.FirstOrDefaultAsync(e => e.Active && e.Id == id);
                return entidad == null
                    ? new OperationResult<GrupoClienteDto>(System.Net.HttpStatusCode.NotFound, "GrupoCliente no encontrado")
                    : await entidad.ToResultAsync<GrupoCliente, GrupoClienteDto>();
            }
            catch (Exception ex)
            {
                return await ex.ToResultAsync<GrupoClienteDto>();
            }
        }

        public async Task<IOperationResult> Update(int id, IOperationRequest<GrupoClienteRequest> entity)
        {
            try
            {
                //entity.Data.GetTotal();

                GrupoCliente? entidad = await _repository.All.FirstOrDefaultAsync(e => e.Active && e.Id == id);
                if (entidad == null)
                {
                    return new OperationResult(System.Net.HttpStatusCode.NotFound, "GrupoCliente no encontrado");
                }

                entidad = entidad.MapTo<GrupoCliente>(entity.Data);

                await _repository.UpdateAsync(entidad);
                await _repository.SaveChangesAsync();
                return new OperationResult(System.Net.HttpStatusCode.NoContent, "GrupoCliente actualizado con éxito");

            }
            catch (Exception ex)
            {
                return await ex.ToResultAsync();
            }

        }
    }
}