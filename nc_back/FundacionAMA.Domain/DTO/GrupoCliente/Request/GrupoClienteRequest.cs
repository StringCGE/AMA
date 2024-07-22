
namespace FundacionAMA.Domain.DTO.GrupoCliente.Request
{
    /// <summary>
    /// Filtro de GrupoCliente
    /// </summary>
    public class GrupoClienteRequest
    {
        /// <summary>
        /// Grupo
        /// </summary>
        public int Grupo_Id  { get; set; }
        /// <summary>
        /// Cliente
        /// </summary>
        public int Cliente_Id  { get; set; }

    }
}