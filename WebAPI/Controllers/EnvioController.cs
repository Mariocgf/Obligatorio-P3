using LogicaAplicacion.InterfacesCasosUso.EnvioCU;
using LogicaNegocio.ExepcionesEntidades;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnvioController : ControllerBase
    {
        private readonly IObtenerEnvio _obtenerEnvio;
        public EnvioController(IObtenerEnvio obtenerEnvio)
        {
            _obtenerEnvio = obtenerEnvio;
        }
        // GET: api/<EnvioController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<EnvioController>/5
        /// <summary>
        /// Permite consultar un envio por su numero de tracking.
        /// </summary>
        /// <param name="nroTracking"> Numero de tracking del envio a consultar.</param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("{nroTracking}")]
        public IActionResult Get(string nroTracking)
        {
            try
            {
                if (String.IsNullOrEmpty(nroTracking))
                    throw new ArgumentNullException("El numero de tracking no puede ser nulo o vacio.");
                return Ok(_obtenerEnvio.Ejecutar(nroTracking));
            }
            catch (EnvioException error)
            {
                return BadRequest(error.Message);
            }
            catch (ArgumentNullException error)
            {
                return BadRequest(error.Message);
            }
            catch (Exception error)
            {
                return StatusCode(500, "Error interno :(");
            }
        }
    }
}
