
using FundacionAMA.Domain.DTO.Cliente.Request;

namespace FundacionAMA.Domain.DTO.Cliente.Dto
{
    /// <summary>
    /// Dto de Cliente
    /// </summary>
    public class ClienteDto : ClienteRequest
    {
        /// <summary>
        /// Id de Cliente
        /// </summary>
        public int Id { get; set; }
    }
}
