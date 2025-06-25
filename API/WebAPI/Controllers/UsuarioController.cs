using Compartido.DTOs;
using Compartido.DTOs.Usuario;
using Compartido.Exceptions;
using LogicaAplicacion.InterfacesCasosUso;
using LogicaAplicacion.InterfacesCasosUso.UsuarioCU;
using LogicaNegocio.ExepcionesEntidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI.JWT;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        //Hacer la inyeccion de dato
        private readonly IUsuarioLogin _usuarioLogin;
        private readonly ICambiarPassword _cambiarPassword;
        public UsuarioController(IUsuarioLogin usuarioLogin, ICambiarPassword cambiarPassword)
        {
            _usuarioLogin = usuarioLogin;
            _cambiarPassword = cambiarPassword;
        }
        // POST api/<UsuarioController>/login
        /// <summary>
        /// Login de un usuario.
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDTO loginDto)
        {
            try
            {
                if (loginDto == null)
                    return BadRequest("Datos vacios");
                UsuarioLoggedDTO usuarioDto = _usuarioLogin.Login(loginDto);
                if (usuarioDto == null)
                    return BadRequest("Datos vacios");
                usuarioDto.Token = ManejadorToken.CrearToken(usuarioDto);
                return Ok(usuarioDto);
            }
            catch (UsuarioException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, "Error interno del servidor :)");
            }
        }
        // PUT api/<UsuarioController>/
        /// <summary>
        /// Cambia la contraseña del usuario autenticado.
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize(Roles = "Cliente")]
        [HttpPut("changePassword")]
        public IActionResult ChangePassword([FromBody] CambioPasswordDto dto)
        {
            try
            {
                if (dto == null)
                    return BadRequest("Datos vacios");
                _cambiarPassword.Ejecutar(dto);
                return NoContent();
            }
            catch (ArgumentException e)
            {
                return NotFound(e.Message);
            }
            catch(ConflictException e)
            {
                return Conflict(e.Message);
            }
            catch(Exception)
            {
                return StatusCode(500, "Error interno del servidor.");
            }
        }
    }
}
