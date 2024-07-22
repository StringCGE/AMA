using FundacionAMA.Application.Services.GrupoClienteApp;
using FundacionAMA.Domain.DTO.GrupoCliente.Dto;
using FundacionAMA.Domain.DTO.GrupoCliente.FilterDto;
using FundacionAMA.Domain.DTO.GrupoCliente.Request;
using FundacionAMA.Domain.Interfaces.Controller.GrupoCliente;
using FundacionAMA.Domain.Shared.Extensions.Bussines;
using FundacionAMA.Domain.Shared.Interfaces.Operations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FundacionAMA.API.Controllers.GrupoCliente
{
    /// <summary>
    /// Reursos para la gestion de GrupoCliente
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class GrupoClienteController : ControllerBase, IGrupoClienteController
    {
        private readonly IGrupoClienteAppService _grupoClienteAppService;
        public GrupoClienteController(IGrupoClienteAppService grupoClienteAppService)
        {
            _grupoClienteAppService = grupoClienteAppService;
        }
        /// <summary>
        /// obtener GrupoCliente por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(IOperationResult<GrupoClienteDto>), 200)]
        [ProducesResponseType(typeof(IOperationResult), 204)]
        [ProducesResponseType(typeof(IOperationResult), 404)]
        [ProducesResponseType(typeof(IOperationResult), 500)]
        public async Task<IActionResult> GetById(int id)
        {
            IOperationResult<GrupoClienteDto> result = await _grupoClienteAppService.GetById(id);
            return StatusCode(result);
        }
        /// <summary>
        /// Obtener todas las GrupoCliente paginado
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(IOperationResultList<GrupoClienteDto>), 200)]
        [ProducesResponseType(typeof(IOperationResult), 204)]
        [ProducesResponseType(typeof(IOperationResult), 404)]
        [ProducesResponseType(typeof(IOperationResult), 500)]
        public async Task<IActionResult> GetAll([FromQuery] GrupoClienteFilter filter)
        {
            IOperationResultList<GrupoClienteDto> result = await _grupoClienteAppService.GetAll(filter);
            return StatusCode(result);
        }
        /// <summary>
        /// creacion de GrupoCliente
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(IOperationResult), 201)]
        [ProducesResponseType(typeof(IOperationResult), 404)]
        [ProducesResponseType(typeof(IOperationResult), 500)]
        public async Task<IActionResult> Create(GrupoClienteRequest entity)
        {
            IOperationResult result = await _grupoClienteAppService.Create(entity.ToRequest(this));
            return StatusCode(result);
        }
        /// <summary>
        ///  actualizar GrupoCliente
        /// </summary>
        /// <param name="id"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(IOperationResultList<GrupoClienteDto>), 200)]
        [ProducesResponseType(typeof(IOperationResult), 204)]
        [ProducesResponseType(typeof(IOperationResult), 404)]
        [ProducesResponseType(typeof(IOperationResult), 500)]
        public async Task<IActionResult> Update(int id, GrupoClienteRequest entity)
        {
            IOperationResult result = await _grupoClienteAppService.Update(id, entity.ToRequest(this));
            return StatusCode(result);
        }
        /// <summary>
        /// eliminar GrupoCliente
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(IOperationResultList<GrupoClienteDto>), 200)]
        [ProducesResponseType(typeof(IOperationResult), 204)]
        [ProducesResponseType(typeof(IOperationResult), 404)]
        [ProducesResponseType(typeof(IOperationResult), 500)]
        public async Task<IActionResult> Delete(int id)
        {
            IOperationResult result = await _grupoClienteAppService.Delete(id.ToRequest(this));
            return StatusCode(result);
        }
    }
}