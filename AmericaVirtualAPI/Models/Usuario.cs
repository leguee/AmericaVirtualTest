using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmericaVirtualAPI.Models
{
    /// <summary>
    /// Datos del usuario
    /// </summary>
    public class Usuario : Entidad
    {
        /// <summary>
        /// Nombre del usuario
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Apellido del usuario
        /// </summary>
        public string Apellido { get; set; }

        /// <summary>
        /// fecha de nacimiento
        /// </summary>
        public DateTime FecNacimiento { get; set; }

        /// <summary>
        /// Email de login
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// pass
        /// </summary>
        public string Pass { get; set; }
    }
}
