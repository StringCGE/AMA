using FundacionAMA.Application.Services.GrupoApp;
using FundacionAMA.Domain.DTO.Grupo.Dto;
using FundacionAMA.Domain.DTO.Grupo.FilterDto;
using FundacionAMA.Domain.DTO.Grupo.Request;
using FundacionAMA.Domain.Interfaces.Controller.Grupo;
using FundacionAMA.Domain.Shared.Extensions.Bussines;
using FundacionAMA.Domain.Shared.Interfaces.Operations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FundacionAMA.API.Controllers.Grupo
{
    /// <summary>
    /// Reursos para la gestion de Grupo
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class GrupoController : ControllerBase, IGrupoController
    {
        private readonly IGrupoAppService _grupoAppService;
        public GrupoController(IGrupoAppService grupoAppService)
        {
            _grupoAppService = grupoAppService;
        }
        /// <summary>
        /// obtener Grupo por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(IOperationResult<GrupoDto>), 200)]
        [ProducesResponseType(typeof(IOperationResult), 204)]
        [ProducesResponseType(typeof(IOperationResult), 404)]
        [ProducesResponseType(typeof(IOperationResult), 500)]
        public async Task<IActionResult> GetById(int id)
        {
            IOperationResult<GrupoDto> result = await _grupoAppService.GetById(id);
            return StatusCode(result);
        }
        /// <summary>
        /// Obtener todas las Grupo paginado
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(IOperationResultList<GrupoDto>), 200)]
        [ProducesResponseType(typeof(IOperationResult), 204)]
        [ProducesResponseType(typeof(IOperationResult), 404)]
        [ProducesResponseType(typeof(IOperationResult), 500)]
        public async Task<IActionResult> GetAll([FromQuery] GrupoFilter filter)
        {
            IOperationResultList<GrupoDto> result = await _grupoAppService.GetAll(filter);
            return StatusCode(result);
        }
        /// <summary>
        /// creacion de Grupo
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(IOperationResult), 201)]
        [ProducesResponseType(typeof(IOperationResult), 404)]
        [ProducesResponseType(typeof(IOperationResult), 500)]
        public async Task<IActionResult> Create(GrupoRequest entity)
        {
            IOperationResult result = await _grupoAppService.Create(entity.ToRequest(this));
            return StatusCode(result);
        }
        /// <summary>
        ///  actualizar Grupo
        /// </summary>
        /// <param name="id"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(IOperationResultList<GrupoDto>), 200)]
        [ProducesResponseType(typeof(IOperationResult), 204)]
        [ProducesResponseType(typeof(IOperationResult), 404)]
        [ProducesResponseType(typeof(IOperationResult), 500)]
        public async Task<IActionResult> Update(int id, GrupoRequest entity)
        {
            IOperationResult result = await _grupoAppService.Update(id, entity.ToRequest(this));
            return StatusCode(result);
        }
        /// <summary>
        /// eliminar Grupo
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(IOperationResultList<GrupoDto>), 200)]
        [ProducesResponseType(typeof(IOperationResult), 204)]
        [ProducesResponseType(typeof(IOperationResult), 404)]
        [ProducesResponseType(typeof(IOperationResult), 500)]
        public async Task<IActionResult> Delete(int id)
        {
            IOperationResult result = await _grupoAppService.Delete(id.ToRequest(this));
            return StatusCode(result);
        }
    }
}