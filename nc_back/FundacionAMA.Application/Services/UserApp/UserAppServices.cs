using FundacionAMA.Domain.DTO.User.Dto;
using FundacionAMA.Domain.DTO.User.FilterDto;
using FundacionAMA.Domain.DTO.User.Request;
using FundacionAMA.Domain.Entities;
using FundacionAMA.Domain.Interfaces.Repositories;
using FundacionAMA.Domain.Shared.Entities.Operation;
using FundacionAMA.Domain.Shared.Extensions.Bussines;
using FundacionAMA.Domain.Shared.Interfaces.Operations;

using Microsoft.EntityFrameworkCore;

using System.Linq.Expressions;

namespace FundacionAMA.Application.Services.UserApp
{
    internal class UserAppService : IUserAppService
    {
        private readonly IUserRepository _userRepository;
        //private readonly IDonorRepository _donorRepository;
        //private readonly IVolunteerRepository _volunteerRepository;

        public UserAppService(IUserRepository userRepository/*, IDonorRepository donorRepository, IVolunteerRepository volunteerRepository*/)
        {
            _userRepository = userRepository;
            //_donorRepository = donorRepository;
            //_volunteerRepository = volunteerRepository;
        }

        public async Task<IOperationResult> Create(IOperationRequest<UserRequest> entity)
        {
            try
            {
                if (await IsExitByIdentification(entity))
                {
                    return new OperationResult(System.Net.HttpStatusCode.BadRequest, $"la User ya existe");
                    //return new OperationResult(System.Net.HttpStatusCode.BadRequest, $"la User con identificación {entity.Data.Nombre} ya existe");
                }
                //entity.Data.GetNameCompleted();
                User user = entity.Data.MapTo<User>();
                
                await _userRepository.InsertAsync(user);
                await _userRepository.SaveChangesAsync(entity);
                return new OperationResult(System.Net.HttpStatusCode.Created, $"la User con identificación pruebano_se_creo_nada se creo correctamente");
            }
            catch (Exception ex)
            {
                return await ex.ToResultAsync();
            }

        }

        private async Task<bool> IsExitByIdentification(IOperationRequest<UserRequest> entity)
        {
            return false;//await _userRepository.ExistsAscyn(e => e.Active && e.Nombre == entity.Data.Nombre);
        }

        public async Task<IOperationResult> Delete(IOperationRequest<int> id)
        {
            try
            {
                User? user = await _userRepository.All.Where(e => e.Active && e.Id == id.Data).FirstOrDefaultAsync();
                if (user == null)
                {
                    return new OperationResult(System.Net.HttpStatusCode.NotFound, $"la User con id {id.Data} no existe");
                }
                await _userRepository.DeleteAsync(user);
                await _userRepository.SaveChangesAsync(id);
                return new OperationResult(System.Net.HttpStatusCode.OK, $"la user con id {id.Data} se elimino correctamente");

            }
            catch (Exception ex)
            {
                return await ex.ToResultAsync();
            }
        }

        public Task<IOperationResultList<UserDto>> GetAll(UserFilter filter)
        {
            Task<IOperationResultList<UserDto>> user = _userRepository.All
                .Where(GetFilters(filter))

                .ToResultListAsync<User, UserDto>(Offset: filter.Offset, Take: filter.Take);

            return user;
        }

        private static Expression<Func<User, bool>> GetFilters(UserFilter filter)
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

        public async Task<IOperationResult<UserDto>> GetById(int id)
        {
            User? user = await _userRepository.All.Where(e => e.Active && e.Id == id).FirstOrDefaultAsync();
            return user == null
                ? new OperationResult<UserDto>(System.Net.HttpStatusCode.NotFound, $"la user con id {id} no existe")
                : await user.ToResultAsync<User, UserDto>();
        }

        public async Task<IOperationResult> Update(int id, IOperationRequest<UserRequest> entity)
        {
            try
            {
                User? user = await _userRepository.All
                    //.Include(e => e.IdNavigation)
                    .Where(e => e.Active && e.Id == id).FirstOrDefaultAsync();
                if (user == null)
                {
                    return new OperationResult(System.Net.HttpStatusCode.NotFound, $"la user con id {id} no existe");
                }
                /*if (await _userRepository.ExistsAscyn(e => e.Active && e.Id != id && e.Identification == entity.Data.Identification))
                {
                    return new OperationResult(System.Net.HttpStatusCode.BadRequest, $"la user con identificación {entity.Data.Identification} ya existe");
                }
                entity.Data.GetNameCompleted();*/

                user = entity.Data.MapTo<User>(user, entity.Data);
                /*if (user.Donor)
                {
                    if (user.IdNavigation == null)
                    {
                        await _donorRepository.InsertAsync(new Donor()
                        {
                            Active = true,
                            UserId = user.Id,
                            Status = "A"
                        });

                    }
                    else
                    {
                        user.IdNavigation.Active = true;
                        user.IdNavigation.UserId = user.Id;
                        user.IdNavigation.Status = "A";
                    }

                }
                else
                {
                    if (user.IdNavigation != null)
                    {
                        user.IdNavigation.Active = false;
                    }

                }


                if (user.Volunteer)
                {

                    if (user.VolunteerNavigation == null)
                    {

                        if (entity.Data.volunaterRequest == null)
                        {
                            return new OperationResult(System.Net.HttpStatusCode.BadRequest,
                                $"Se debe proporcionar datos si es voluntario");
                        }
                        entity.Data.volunaterRequest.MapTo<Volunteer>();
                        Volunteer volunet = entity.Data.volunaterRequest.MapTo<Volunteer>();
                        volunet.UserId = user.Id;
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
                        volunterEntity.UserId = user.Id;
                        user.VolunteerNavigation = volunterEntity;
                    }

                }
                else
                {
                    if (user.VolunteerNavigation != null)
                    {
                        user.VolunteerNavigation.Active = false;
                    }

                }

                if (user.Beneficiary != null)
                {
                    user.Beneficiary.UserId = user.Id;


                }*/
                await _userRepository.UpdateAsync(user);
                await _userRepository.SaveChangesAsync(entity);
                return new OperationResult(System.Net.HttpStatusCode.OK, $"la user con id {id} se actualizo correctamente");
            }
            catch (Exception ex)
            {
                return await ex.ToResultAsync();
            }
        }
    }
}
