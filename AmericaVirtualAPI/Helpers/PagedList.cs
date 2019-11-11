using System;
using System.Collections.Generic;
using System.Linq;

namespace AmericaVirtualAPI.Helpers
{
    /// <summary>
    /// clase para el manejo y devolucion de informacion de paginado mediante metadata
    /// </summary>
    public class PagedList<T> : List<T>
    {
        /// <summary>
        /// pagina actual
        /// </summary>
        public int CurrentPage { get; private set; }

        /// <summary>
        /// Total de paginas del conjunto de datos
        /// </summary>
        public int TotalPages { get; private set; }

        /// <summary>
        /// tamaño de pagina
        /// </summary>
        public int PageSize { get; private set; }

        /// <summary>
        /// Cantidad total de elementos
        /// </summary>
        public int TotalCount { get; private set; }

        /// <summary>
        /// Indica si tiene pagina previa
        /// </summary>
        public bool HasPrevious
        {
            get
            {
                return (CurrentPage > 1);
            }
        }

        /// <summary>
        /// indica si tiene una pagina siguiente
        /// </summary>
        public bool HasNext
        {
            get
            {
                return (CurrentPage < TotalPages);
            }
        }

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="items">lista de elementos</param>
        /// <param name="count">cantidad de elementos</param>
        /// <param name="pageNumber">numero de pagina</param>
        /// <param name="pageSize">tamaño de pagina</param>
        public PagedList(List<T> items, int count, int pageNumber, int pageSize)
        {
            TotalCount = count;
            PageSize = pageSize;
            CurrentPage = pageNumber;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            AddRange(items);
        }

        /// <summary>
        /// devuelve el conjunto de datos paginado segun lo solicitado
        /// </summary>
        /// <param name="source">source</param>
        /// <param name="pageNumber">numero de pagona</param>
        /// <param name="pageSize">tamaño de pagina</param>
        /// <returns>lista de elemntos segun paginado</returns>
        public static PagedList<T> Create(IQueryable<T> source, int pageNumber, int pageSize)
        {
            var count = source.Count();
            var items = source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
            return new PagedList<T>(items, count, pageNumber, pageSize);
        }
    }
}
