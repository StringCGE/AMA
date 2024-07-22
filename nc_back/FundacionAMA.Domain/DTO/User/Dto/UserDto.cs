
using FundacionAMA.Domain.DTO.User.Request;

namespace FundacionAMA.Domain.DTO.User.Dto
{
    /// <summary>
    /// Dto de User
    /// </summary>
    public class UserDto : UserRequest
    {
        /// <summary>
        /// Id de User
        /// </summary>
        public int Id { get; set; }
    }
}
