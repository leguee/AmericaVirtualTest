using System;

namespace AmericaVirtualAPI.Models
{
    /// <summary>
    /// Clase de la que deben heredar los modelos para hacer uso del repository
    /// (propiedades comunes entre modelos)
    /// </summary>
    public class Entidad
    {
        /// <summary>
        /// Id de los modelos
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Fecha de creacion del registro
        /// </summary>
        public DateTime FechaCreacion { get; set; }
    }
}
