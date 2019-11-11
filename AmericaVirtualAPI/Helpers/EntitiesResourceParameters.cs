using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmericaVirtualAPI.Helpers
{
    /// <summary>
    /// clase de manejo de los parametros del llamado a la API, paginado y filtrado
    /// </summary>
    public class EntitiesResourceParameters
    {
        /// <summary>
        /// maximo tamaño de pagina
        /// </summary>
        const int maxPageSize = 20;

        /// <summary>
        /// nupero de pagina
        /// </summary>
        public int PageNumber { get; set; } = 1;

        /// <summary>
        /// tamaño de pagina por defecto
        /// </summary>
        private int _pageSize = 10;

        /// <summary>
        /// Tamaño de pagina
        /// </summary>
        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = (value > maxPageSize) ? maxPageSize : value;
            }
        }
    }
}
