using AmericaVirtualAPI.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmericaVirtualAPI.Services
{
    /// <summary>
    /// interface del patron repository
    /// </summary>
    /// <typeparam name="T">clase parametrizable</typeparam>
    public interface IRepository<T>
    {
        /// <summary>
        /// Obtener lista de elementos segun parametros
        /// </summary>
        /// <param name="todosResourceParameters">parametros de devolucion</param>
        /// <returns>lista paginada de elementos</returns>
        PagedList<T> GetAll(EntitiesResourceParameters todosResourceParameters);

        /// <summary>
        /// obtiene elemento dado el Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>elemento encontrado</returns>
        T GetById(long id);

        /// <summary>
        /// Agrega nuevo elemento a la bd
        /// </summary>
        /// <param name="Item"></param>
        void Add(T Item);

        /// <summary>
        /// Actualiza elemento en la bd
        /// </summary>
        /// <param name="Item"></param>
        void Update(T Item);

        /// <summary>
        /// guarda la transaccion
        /// </summary>
        /// <returns>exito o fail</returns>
        bool Save();
    }
}
