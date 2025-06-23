using Compartido.DTOs.Envio;
using LogicaAplicacion.InterfacesCasosUso.EnvioCU;
using LogicaNegocio.ExepcionesEntidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnvioController : ControllerBase
    {
        private readonly IObtenerEnvio _obtenerEnvio;
        private readonly IObtenerEnvioUsuario _obtenerEnviosUsuario;
        private readonly IBuscarEnvioXFechaUsuario _buscarEnvioXFechaUsuario;
        private readonly IBuscarEnvioXComentario _buscarEnvioXComentario;
        private readonly IObtenerSeguimientos _obtenerSeguimientos;
        public EnvioController(IObtenerEnvio obtenerEnvio,
                                IObtenerEnvioUsuario obtenerEnviosUsuario,
                                IBuscarEnvioXFechaUsuario buscarEnvioXFechaUsuario,
                                IBuscarEnvioXComentario buscarEnvioXComentario,
                                IObtenerSeguimientos obtenerSeguimientos)
        {
            _obtenerEnvio = obtenerEnvio;
            _obtenerEnviosUsuario = obtenerEnviosUsuario;
            _buscarEnvioXFechaUsuario = buscarEnvioXFechaUsuario;
            _buscarEnvioXComentario = buscarEnvioXComentario;
            _obtenerSeguimientos = obtenerSeguimientos;
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
                    return BadRequest("Datos vacios");
                return Ok(_obtenerEnvio.Ejecutar(nroTracking));
            }
            catch (EnvioException error)
            {
                return BadRequest(error.Message);
            }
            catch (Exception error)
            {
                return StatusCode(500, "Error interno :(");
            }
        }
        [Authorize(Roles = "Cliente")]
        [HttpGet("usuario/{id}")]
        public IActionResult GetEnviosUsuario(int id)
        {
            try
            {
                if (id <= 0)
                    return BadRequest("El ID del usuario debe ser mayor a 0.");
                List<EnvioUsuarioDto> envios = _obtenerEnviosUsuario.Ejecutar(id);
                return Ok(envios);
            }
            catch (EnvioException error)
            {
                return BadRequest(error.Message);
            }
            catch (Exception error)
            {
                return StatusCode(500, "Error interno :(");
            }
        }
        [Authorize(Roles = "Cliente")]
        [HttpGet("fecha")]
        public IActionResult GetEnvioFechaUsuario([FromQuery] EnvioXFechaDto dto)
        {
            try
            {
                if (dto == null)
                    return BadRequest("Datos vacios");
                if (dto.IdUser <= 0)
                    return BadRequest("El ID del usuario debe ser mayor a 0.");
                if (dto.FechaDesde > dto.FechaHasta)
                    return BadRequest("La fecha de inicio no puede ser mayor que la fecha de fin.");
                List<EnvioUsuarioDto> envios = _buscarEnvioXFechaUsuario.Ejecutar(dto);
                return Ok(envios);
            }
            catch (ArgumentException e)
            {
                return BadRequest(e.Message);
            }
        }
        [Authorize(Roles = "Cliente")]
        [HttpGet("comentario")]
        public IActionResult GetEnvioXComentario([FromQuery] EnvioXComentarioDto dto)
        {
            try
            {
                if (dto is null)
                    return BadRequest("Datos vacios");
                return Ok(_buscarEnvioXComentario.Ejecutar(dto.Comentario.ToUpper(), dto.IdUser));
            }
            catch (ArgumentException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno del servidor.");
            }
        }
        [Authorize(Roles = "Cliente")]
        [HttpGet("seguimientos/{idEnvio}")]
        public IActionResult GetSeguimientos(int idEnvio)
        {
            try
            {
                if (idEnvio <= 0)
                    return BadRequest("El ID de envío debe ser válido.");
                return Ok(_obtenerSeguimientos.Ejecutar(idEnvio));
            }
            catch (ArgumentException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception error)
            {
                return StatusCode(500, "Error interno del servidor.");
            }
        }
    }
}
