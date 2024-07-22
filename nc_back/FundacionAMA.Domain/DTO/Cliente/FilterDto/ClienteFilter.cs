
using FundacionAMA.Domain.Shared.Entities.Dtos;

namespace FundacionAMA.Domain.DTO.Cliente.FilterDto
{
    /// <summary>
    /// Filtro de Cliente
    /// </summary>
    public class ClienteFilter : RequestPaginated
    {
        /// <summary>
        /// Codigo
        /// </summary>
        public string Codigo  { get; set; }
        /// <summary>
        /// PrimeraCompra
        /// </summary>
        public string PrimeraCompra  { get; set; }

    }
}