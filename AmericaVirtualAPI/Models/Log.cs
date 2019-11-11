using System;

namespace AmericaVirtualAPI.Models
{
    /// <summary>
    /// Modelo para log de acciones por partes del usuario 
    /// </summary>
    public class Log : Entidad
    {
        /// <summary>
        /// Id del usuario que realiza la accion
        /// </summary>
        public string UsuarioId { get; set; }

        /// <summary>
        /// accion que realiza el usuario
        /// </summary>
        public string Accion { get; set; }

        /// <summary>
        /// Descripcion de la accion a logear
        /// </summary>
        public string Descripcion { get; set; }

        /// <summary>
        /// fecha de la accion
        /// </summary>
        public DateTime FechaActual { get; set; }
    }
}
