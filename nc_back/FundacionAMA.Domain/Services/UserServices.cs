using FundacionAMA.Domain.DTO.User.Dto;
//using FundacionAMA.Domain.DTO.User.Filter;
using FundacionAMA.Domain.DTO.User.FilterDto;
using FundacionAMA.Domain.DTO.User.Request;

namespace FundacionAMA.Domain.Services
{
    internal class UserService : IUserService
    {
        public readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<IOperationResult> Create(IOperationRequest<UserRequest> entity)
        {
            try
            {
                //entity.Data.GetTotal();
                User donacionEntiy = entity.Data.MapTo<User>();
                await _repository.InsertAsync(donacionEntiy);
                await _repository.SaveChangesAsync();
                return new OperationResult(System.Net.HttpStatusCode.Created, "User creado con éxito");

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
                User? entidad = await _repository.All.FirstOrDefaultAsync(e => e.Active && e.Id == id.Data);

                if (entidad == null)
                {
                    return new OperationResult(System.Net.HttpStatusCode.NotFound, "User no encontrado");
                }

                await _repository.DeleteAsync(entidad);
                await _repository.SaveChangesAsync();
                return new OperationResult(System.Net.HttpStatusCode.NoContent, "User eliminado con éxito");
            }
            catch (Exception ex)
            {
                return await ex.ToResultAsync();
            }
        }

        public async Task<IOperationResultList<UserDto>> GetAll(UserFilter filter)
        {
            try
            {
                IOperationResultList<UserDto> entidad = await _repository

                    .All
                    //.Include(e => e.UserType)
                    .Where(
                    e => e.Active
                    /*&& (string.IsNullOrWhiteSpace(filter.Name) || e.Name.Contains(filter.Name))

                    && (filter.PersonId == null || e.PersonId == filter.PersonId)
                    && (filter.Id == null || e.Id == filter.Id)
                    && (filter.BrigadeId == null || e.PersonId == filter.BrigadeId)
                    && (filter.UserTypeId == null || e.UserTypeId == filter.UserTypeId)
                    */
                    )
                    .ToResultListAsync<User, UserDto>(Offset: filter.Offset, Take: filter.Take);

                return entidad;

            }
            catch (Exception ex)
            {
                return await ex.ToResultListAsync<UserDto>();
            }
        }

        public async Task<IOperationResult<UserDto>> GetById(int id)
        {
            try
            {
                User? entidad = await _repository.All.FirstOrDefaultAsync(e => e.Active && e.Id == id);
                return entidad == null
                    ? new OperationResult<UserDto>(System.Net.HttpStatusCode.NotFound, "User no encontrado")
                    : await entidad.ToResultAsync<User, UserDto>();
            }
            catch (Exception ex)
            {
                return await ex.ToResultAsync<UserDto>();
            }
        }

        public async Task<IOperationResult> Update(int id, IOperationRequest<UserRequest> entity)
        {
            try
            {
                //entity.Data.GetTotal();

                User? entidad = await _repository.All.FirstOrDefaultAsync(e => e.Active && e.Id == id);
                if (entidad == null)
                {
                    return new OperationResult(System.Net.HttpStatusCode.NotFound, "User no encontrado");
                }

                entidad = entidad.MapTo<User>(entity.Data);

                await _repository.UpdateAsync(entidad);
                await _repository.SaveChangesAsync();
                return new OperationResult(System.Net.HttpStatusCode.NoContent, "User actualizado con éxito");

            }
            catch (Exception ex)
            {
                return await ex.ToResultAsync();
            }

        }
    }
}