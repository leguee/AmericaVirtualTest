using AmericaVirtualAPI.Helpers;
using AmericaVirtualAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmericaVirtualAPI.Services
{
    /// <summary>
    /// repositorio de usuarios
    /// </summary>
    public interface IUserRepository: IRepository<Usuario>
    {
        /// <summary>
        /// Obtener usuario dado los datos de login
        /// </summary>
        /// <param name="email">email del usuario</param>
        /// <param name="pass">contraseña</param>
        /// <returns>detalle del usuario</returns>
        Usuario GetUsuarioByLogin(string email, string pass);
    }
}
