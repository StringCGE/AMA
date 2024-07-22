
using FundacionAMA.Domain.DTO.GrupoCliente.Request;

namespace FundacionAMA.Domain.DTO.GrupoCliente.Dto
{
    /// <summary>
    /// Dto de GrupoCliente
    /// </summary>
    public class GrupoClienteDto : GrupoClienteRequest
    {
        /// <summary>
        /// Id de GrupoCliente
        /// </summary>
        public int Id { get; set; }
    }
}
