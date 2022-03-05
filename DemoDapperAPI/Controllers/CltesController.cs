using DemoDapperAPI.Models;
using DemoDapperAPI.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DemoDapperAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CltesController : ControllerBase
    {
        //Crear método que permita retornar todos los datos de forma síncrona.
        // GET: api/<CltesController>
        [HttpGet]
        public ActionResult<IEnumerable<Clte>> Get()
        {
            var clienteService = new ClteService();
            {
                var cliente = clienteService.GetClientes();
                if (cliente != null)
                {
                    return Ok(cliente);
                }
                return NotFound("Aviso:No hay clientes");
            }
        }
        //Crear método que permita retornar los datos por ID de forma síncrona.
        // GET api/<CltesController>/5
        [HttpGet("{id}")]
        public ActionResult<Clte> Get(int id)
        {
            var clienteService = new ClteService();
            {
                var cliente = clienteService.GetClienteById(id);
                if (cliente != null)
                {
                    return Ok(cliente);
                }
                return NotFound("Aviso:No hay cliente con ese id: " + id);
            }
        }
        //Crear método que permita ingresar datos de forma asíncrona.

        //api/clte/async
        [HttpPost]
        [Route("ASYNC")]
        public async Task PostAsync([FromBody] Clte cliente)
        {
            try
            {
                var clienteService = new ClteService();
                {
                    cliente.id = 0;
                    await clienteService.AddClientAsync(cliente);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        //Crear método que permita actualizar datos de forma asíncrona

        [HttpPut("{id}")]
        [Route("ASYNC")]
        public async Task PutAsync([FromBody] Clte cliente)
        {
            try
            {
                var clienteService = new ClteService();
                {
                    await clienteService.UpdateClientAsync(cliente);
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }

    } 
}
