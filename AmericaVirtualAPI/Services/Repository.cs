using AmericaVirtualAPI.Helpers;
using AmericaVirtualAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmericaVirtualAPI.Services
{
    /// <summary>
    /// implemetacion de los metodos de la API genericos
    /// </summary>
    public class Repository<T> : IRepository<T> where T : Entidad, new()
    {
        private ApiContext _context;

        public Repository(ApiContext context)
        {
            _context = context;
        }

        /// <summary>
        /// obtiene el listado de entidad segun la paginacion
        /// </summary>
        /// <param name="itemResourceParameters"></param>
        /// <returns></returns>
        public PagedList<T> GetAll(EntitiesResourceParameters itemResourceParameters)
        {
            var collectionBeforePaging =
             _context.Set<T>()
             .OrderBy(a => a.Id)
             .AsQueryable();

            return PagedList<T>.Create(collectionBeforePaging,
                itemResourceParameters.PageNumber,
                itemResourceParameters.PageSize);
        }

        /// <summary>
        /// metodo que agrega una nueva entidad a la coleccion
        /// </summary>
        /// <param name="entidad"></param>
        public void Add(T entidad)
        {
            _context.Set<T>().Add(entidad);
        }

        /// <summary>
        /// obtiene la entidad dado el id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T GetById(long id)
        {
            return _context.Set<T>().FirstOrDefault(a => a.Id == id);
        }

        /// <summary>
        /// actualiza la entidad dada
        /// </summary>
        /// <param name="entidad"></param>
        public void Update(T entidad)
        {
            _context.Entry(entidad).State = EntityState.Modified;
        }

        /// <summary>
        /// consulta si se registró la transaccion
        /// </summary>
        /// <returns></returns>
        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }
        
    }
}
