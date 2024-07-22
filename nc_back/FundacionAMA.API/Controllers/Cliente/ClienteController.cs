using FundacionAMA.Application.Services.ClienteApp;
using FundacionAMA.Domain.DTO.Cliente.Dto;
using FundacionAMA.Domain.DTO.Cliente.FilterDto;
using FundacionAMA.Domain.DTO.Cliente.Request;
using FundacionAMA.Domain.Interfaces.Controller.Cliente;
using FundacionAMA.Domain.Shared.Extensions.Bussines;
using FundacionAMA.Domain.Shared.Interfaces.Operations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FundacionAMA.API.Controllers.Cliente
{
    /// <summary>
    /// Reursos para la gestion de Cliente
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class ClienteController : ControllerBase, IClienteController
    {
        private readonly IClienteAppService _clienteAppService;
        public ClienteController(IClienteAppService clienteAppService)
        {
            _clienteAppService = clienteAppService;
        }
        /// <summary>
        /// obtener Cliente por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(IOperationResult<ClienteDto>), 200)]
        [ProducesResponseType(typeof(IOperationResult), 204)]
        [ProducesResponseType(typeof(IOperationResult), 404)]
        [ProducesResponseType(typeof(IOperationResult), 500)]
        public async Task<IActionResult> GetById(int id)
        {
            IOperationResult<ClienteDto> result = await _clienteAppService.GetById(id);
            return StatusCode(result);
        }
        /// <summary>
        /// Obtener todas las Cliente paginado
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(IOperationResultList<ClienteDto>), 200)]
        [ProducesResponseType(typeof(IOperationResult), 204)]
        [ProducesResponseType(typeof(IOperationResult), 404)]
        [ProducesResponseType(typeof(IOperationResult), 500)]
        public async Task<IActionResult> GetAll([FromQuery] ClienteFilter filter)
        {
            IOperationResultList<ClienteDto> result = await _clienteAppService.GetAll(filter);
            return StatusCode(result);
        }
        /// <summary>
        /// creacion de Cliente
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(IOperationResult), 201)]
        [ProducesResponseType(typeof(IOperationResult), 404)]
        [ProducesResponseType(typeof(IOperationResult), 500)]
        public async Task<IActionResult> Create(ClienteRequest entity)
        {
            IOperationResult result = await _clienteAppService.Create(entity.ToRequest(this));
            return StatusCode(result);
        }
        /// <summary>
        ///  actualizar Cliente
        /// </summary>
        /// <param name="id"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(IOperationResultList<ClienteDto>), 200)]
        [ProducesResponseType(typeof(IOperationResult), 204)]
        [ProducesResponseType(typeof(IOperationResult), 404)]
        [ProducesResponseType(typeof(IOperationResult), 500)]
        public async Task<IActionResult> Update(int id, ClienteRequest entity)
        {
            IOperationResult result = await _clienteAppService.Update(id, entity.ToRequest(this));
            return StatusCode(result);
        }
        /// <summary>
        /// eliminar Cliente
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(IOperationResultList<ClienteDto>), 200)]
        [ProducesResponseType(typeof(IOperationResult), 204)]
        [ProducesResponseType(typeof(IOperationResult), 404)]
        [ProducesResponseType(typeof(IOperationResult), 500)]
        public async Task<IActionResult> Delete(int id)
        {
            IOperationResult result = await _clienteAppService.Delete(id.ToRequest(this));
            return StatusCode(result);
        }
    }
}