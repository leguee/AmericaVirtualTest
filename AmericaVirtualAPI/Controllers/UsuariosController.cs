using AmericaVirtualAPI.Helpers;
using AmericaVirtualAPI.Models;
using AmericaVirtualAPI.Services;
using Library.API.Helpers;
using Microsoft.AspNetCore.Mvc;
using System;

namespace AmericaVirtualAPI.Controllers
{
    /// <summary>
    /// Controlador de Usuarios
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private IUserRepository _usuarioRepository;

        /// <summary>
        /// constructor del controlador
        /// </summary>
        /// <param name="usuarioRepository">repositorio</param>
        public UsuariosController(IUserRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        /// <summary>
        /// login de usuario
        /// </summary>
        /// <param name="usuario">datos del form de login</param>
        /// <returns>datos del usuario</returns>
        [HttpPost]
        public IActionResult GetLogin([FromBody] Usuario usuario)
        {
            var usuarioFromRepo = _usuarioRepository.GetUsuarioByLogin(usuario.Email, usuario.Pass);

            if (usuarioFromRepo == null)
            {
                return NotFound();
            }

            return Ok(usuarioFromRepo);
        }

        // GET api/usuarios/1
        /// <summary>
        /// Obtiene detalle de usuario dado el Id
        /// </summary>
        /// <param name="id">Id del usuario</param>
        /// <returns>Detalle del usuario</returns>
        [HttpGet("{id}", Name = "GetUsuario")]
        public IActionResult GetUsuario(long id)
        {
            var usuarioFromRepo = _usuarioRepository.GetById(id);

            if (usuarioFromRepo == null)
            {
                return NotFound();
            }
            
            return Ok(usuarioFromRepo);
        }
        
        // PUT api/usuarios/5
        /// <summary>
        /// Actualiza datos del usuario
        /// </summary>
        /// <param name="id">Id del usuario</param>
        /// <param name="value">Datos del usuario a actualizar</param>
        /// <returns>Usuario actualizado</returns>
        [HttpPut("{id}")]
        public IActionResult UpdateUsuario(long id, Usuario value)
        {
            if (id != value.Id)
            {
                return BadRequest();
            }

            _usuarioRepository.Update(value);

            if (!_usuarioRepository.Save())
            {
                return StatusCode(500, "A problem happened with handling your request.");
            }

            // devuelve el usuario 
            return CreatedAtRoute("GetUsuario",
                new { id = value.Id },
                value);
        }

     
    }
}