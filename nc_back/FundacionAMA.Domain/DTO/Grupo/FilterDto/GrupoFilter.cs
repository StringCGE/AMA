
using FundacionAMA.Domain.Shared.Entities.Dtos;

namespace FundacionAMA.Domain.DTO.Grupo.FilterDto
{
    /// <summary>
    /// Filtro de Grupo
    /// </summary>
    public class GrupoFilter : RequestPaginated
    {
        /// <summary>
        /// Nombre
        /// </summary>
        public string Nombre  { get; set; }

    }
}