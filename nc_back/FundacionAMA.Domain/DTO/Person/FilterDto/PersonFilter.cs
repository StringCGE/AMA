
using FundacionAMA.Domain.Shared.Entities.Dtos;

namespace FundacionAMA.Domain.DTO.Person.FilterDto
{
    /// <summary>
    /// Filtro de Person
    /// </summary>
    public class PersonFilter : RequestPaginated
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

    }
}