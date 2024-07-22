
using FundacionAMA.Domain.Shared.Entities.Dtos;

namespace FundacionAMA.Domain.DTO.User.FilterDto
{
    /// <summary>
    /// Filtro de User
    /// </summary>
    public class UserFilter : RequestPaginated
    {
        /// <summary>
        /// Usuario
        /// </summary>
        public string Usuario  { get; set; }
        /// <summary>
        /// Clave
        /// </summary>
        public string Clave  { get; set; }
        /// <summary>
        /// Nombre
        /// </summary>
        public string Nombre  { get; set; }

    }
}