using API_ABAN.Models.Dtos;
using API_ABAN.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace API_ABAN.Controllers
{
    [Route("clientes")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteService _clienteService;
        private readonly ILogger<ClientesController> _logger;

        public ClientesController(IClienteService clienteService, ILogger<ClientesController> logger)
        {
            _clienteService = clienteService;
            _logger = logger;
        }

        /// <summary>
        /// Obtiene un listado de Clientes.
        /// </summary>
        /// <returns></returns>
        [HttpGet(Name = "Get")]
        public async Task<IEnumerable<ClienteDTO>> GetCliente()
        {
            _logger.LogInformation("Obtener Clientes.");
            return await _clienteService.GetClientesAsync();
        }

        /// <summary>
        /// Consulta clientes por ID.
        /// </summary>
        /// <param name="id">Id del Cliente a consultar.</param>
        /// <returns></returns>
        [HttpGet("Id", Name = "GetByIdCliente")]
        public async Task<ActionResult<ClienteDTO>> GetByIdCliente(int id)
        {
            _logger.LogInformation("Obtener Clientes por ID.");

            var cliente = await _clienteService.GetClienteByIdAsync(id);

            if (cliente == null)
            {
                return NotFound(new { message = "No se encontró el cliente solicitado." });
            }

            return cliente;
        }

        /// <summary>
        /// Filtro de clientes por Nombre, colocando una o varias letras, busca los nombres que contengan esas letras
        /// </summary>
        /// <param name="name">Nombre del Cliente a consultar.</param>
        /// <returns></returns>
        [HttpGet("Name", Name = "FilterByNameCliente")]
        public async Task<IActionResult> FilterByNameCliente(string name)
        {
            _logger.LogInformation("Obtener Clientes por Nombre.");

            var cliente = await _clienteService.FilterClientesByNameAsync(name);

            if (cliente == null || !cliente.Any())
            {
                return NotFound(new { message = "No se encontraron clientes con los criterios indicados." });
            }

            return Ok(cliente);
        }

        /// <summary>
        /// Crear un nuevo cliente con su dirección.
        /// </summary>
        /// <param name="clienteCreateDTO"></param>
        /// <returns></returns>
        [HttpPost(Name = "Post")]
        public async Task<ActionResult> PostCliente(ClienteCreateDTO clienteCreateDTO)
        {
            _logger.LogInformation("Insertar Clientes.");

            var clienteId = await _clienteService.CreateClienteAsync(clienteCreateDTO);
            return Ok(new { message = "Cliente agregado correctamente.", clienteId });
        }

        /// <summary>
        /// Modifica un cliente con su dirección.
        /// </summary>
        /// <param name="id">Id del Cliente a modificar.</param>
        /// <param name="clienteUpdateDTO"></param>
        /// <returns></returns>
        [HttpPut("{id}", Name = "Put")]
        public async Task<ActionResult> PutCliente(int id, ClienteUpdateDTO clienteUpdateDTO)
        {
            _logger.LogInformation("Actualizar Clientes.");

            await _clienteService.UpdateClienteAsync(clienteUpdateDTO, id);
            return Ok(new { message = "Cliente Modificado correctamente." });
        }

        /// <summary>
        /// Delete Lógico de Clientes.
        /// </summary>
        /// <param name="id">Id del Cliente a marcar como eliminado.</param>
        /// <returns></returns>
        [HttpDelete(Name = "Delete")]
        public async Task<ActionResult> DeleteCliente(int id)
        {
            _logger.LogInformation("Eliminar Clientes.");

            await _clienteService.SoftDeleteClienteAsync(id);
            return Ok(new { message = "Cliente Eliminado correctamente." });
        }

        /// <summary>
        /// Restaurar registro con Delete Lógico.
        /// </summary>
        /// <param name="id">Id del Cliente marcado como eliminado que se quiere rastaurar.</param>
        /// <returns></returns>
        [HttpPost("id", Name = "Restaurar")]
        public async Task<ActionResult> RestaurarCliente(int id)
        {
            _logger.LogInformation("Restaurar Clientes.");

            await _clienteService.RestoreClienteAsync(id);
            return Ok(new { message = "Cliente Restaurado correctamente."});
        }
    }
}
