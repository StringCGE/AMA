using FundacionAMA.Domain.DTO.Grupo.Dto;
//using FundacionAMA.Domain.DTO.Grupo.Filter;
using FundacionAMA.Domain.DTO.Grupo.FilterDto;
using FundacionAMA.Domain.DTO.Grupo.Request;

namespace FundacionAMA.Domain.Services
{
    internal class GrupoService : IGrupoService
    {
        public readonly IGrupoRepository _repository;

        public GrupoService(IGrupoRepository repository)
        {
            _repository = repository;
        }

        public async Task<IOperationResult> Create(IOperationRequest<GrupoRequest> entity)
        {
            try
            {
                //entity.Data.GetTotal();
                Grupo donacionEntiy = entity.Data.MapTo<Grupo>();
                await _repository.InsertAsync(donacionEntiy);
                await _repository.SaveChangesAsync();
                return new OperationResult(System.Net.HttpStatusCode.Created, "Grupo creado con éxito");

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
                Grupo? entidad = await _repository.All.FirstOrDefaultAsync(e => e.Active && e.Id == id.Data);

                if (entidad == null)
                {
                    return new OperationResult(System.Net.HttpStatusCode.NotFound, "Grupo no encontrado");
                }

                await _repository.DeleteAsync(entidad);
                await _repository.SaveChangesAsync();
                return new OperationResult(System.Net.HttpStatusCode.NoContent, "Grupo eliminado con éxito");
            }
            catch (Exception ex)
            {
                return await ex.ToResultAsync();
            }
        }

        public async Task<IOperationResultList<GrupoDto>> GetAll(GrupoFilter filter)
        {
            try
            {
                IOperationResultList<GrupoDto> entidad = await _repository

                    .All
                    //.Include(e => e.GrupoType)
                    .Where(
                    e => e.Active
                    /*&& (string.IsNullOrWhiteSpace(filter.Name) || e.Name.Contains(filter.Name))

                    && (filter.PersonId == null || e.PersonId == filter.PersonId)
                    && (filter.Id == null || e.Id == filter.Id)
                    && (filter.BrigadeId == null || e.PersonId == filter.BrigadeId)
                    && (filter.GrupoTypeId == null || e.GrupoTypeId == filter.GrupoTypeId)
                    */
                    )
                    .ToResultListAsync<Grupo, GrupoDto>(Offset: filter.Offset, Take: filter.Take);

                return entidad;

            }
            catch (Exception ex)
            {
                return await ex.ToResultListAsync<GrupoDto>();
            }
        }

        public async Task<IOperationResult<GrupoDto>> GetById(int id)
        {
            try
            {
                Grupo? entidad = await _repository.All.FirstOrDefaultAsync(e => e.Active && e.Id == id);
                return entidad == null
                    ? new OperationResult<GrupoDto>(System.Net.HttpStatusCode.NotFound, "Grupo no encontrado")
                    : await entidad.ToResultAsync<Grupo, GrupoDto>();
            }
            catch (Exception ex)
            {
                return await ex.ToResultAsync<GrupoDto>();
            }
        }

        public async Task<IOperationResult> Update(int id, IOperationRequest<GrupoRequest> entity)
        {
            try
            {
                //entity.Data.GetTotal();

                Grupo? entidad = await _repository.All.FirstOrDefaultAsync(e => e.Active && e.Id == id);
                if (entidad == null)
                {
                    return new OperationResult(System.Net.HttpStatusCode.NotFound, "Grupo no encontrado");
                }

                entidad = entidad.MapTo<Grupo>(entity.Data);

                await _repository.UpdateAsync(entidad);
                await _repository.SaveChangesAsync();
                return new OperationResult(System.Net.HttpStatusCode.NoContent, "Grupo actualizado con éxito");

            }
            catch (Exception ex)
            {
                return await ex.ToResultAsync();
            }

        }
    }
}