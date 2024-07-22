
namespace FundacionAMA.Domain.DTO.Person.Request
{
    /// <summary>
    /// Filtro de Person
    /// </summary>
    public class PersonRequest
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