
namespace FundacionAMA.Domain.DTO.Cliente.Request
{
    /// <summary>
    /// Filtro de Cliente
    /// </summary>
    public class ClienteRequest
    {
        /// <summary>
        /// Nombre
        /// </summary>
        public string Nombre  { get; set; }
        /// <summary>
        /// Apellido
        /// </summary>
        public string Apellido  { get; set; }
        /// <summary>
        /// Edad
        /// </summary>
        public int Edad  { get; set; }
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