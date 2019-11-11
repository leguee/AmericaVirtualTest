using AmericaVirtualAPI.Models;
using AmericaVirtualAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace AmericaVirtualAPI.Controllers
{
    /// <summary>
    /// controlador de logs
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class LogsController : ControllerBase
    {
        private IRepository<Log> _logRepository;

        /// <summary>
        /// Constructor del controlador
        /// </summary>
        /// <param name="logRepository">repositorio log</param>
        public LogsController(IRepository<Log> logRepository)
        {
            _logRepository = logRepository;
        }

        /// <summary>
        /// Alta de Logs
        /// </summary>
        /// <param name="value">Nuevo log</param>
        /// <returns>log insertado</returns>
        // POST api/logs
        [HttpPost]
        public IActionResult Post([FromBody]Log value)
        {
            if (value == null)
            {
                return BadRequest();
            }

            _logRepository.Add(value);

            if (!_logRepository.Save())
            {
                return StatusCode(500, "A problem happened with handling your request.");
            }

            // devuelve el log creado
            return CreatedAtRoute("GetLog",
                new { id = value.Id },
                value);
        }

        // GET api/logs/1
        /// <summary>
        /// Obtiene log dado el Id
        /// </summary>
        /// <param name="id">id del log</param>
        /// <returns>Log encontrado</returns>
        [HttpGet("{id}", Name = "GetLog")]
        public IActionResult GetLog(long id)
        {
            var logFromRepo = _logRepository.GetById(id);

            if (logFromRepo == null)
            {
                return NotFound();
            }
            
            return Ok(logFromRepo);
        }
    }
}