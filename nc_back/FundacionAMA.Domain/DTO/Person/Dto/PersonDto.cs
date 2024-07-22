
using FundacionAMA.Domain.DTO.Person.Request;

namespace FundacionAMA.Domain.DTO.Person.Dto
{
    /// <summary>
    /// Dto de Person
    /// </summary>
    public class PersonDto : PersonRequest
    {
        /// <summary>
        /// Id de Person
        /// </summary>
        public int Id { get; set; }
    }
}
