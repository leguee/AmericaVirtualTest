using AmericaVirtualAPI.Models;
using System.Linq;

namespace AmericaVirtualAPI.Services
{
    /// <summary>
    /// implemetacion del repositorio de usuario
    /// </summary>
    public class UserRepository : Repository<Usuario> , IUserRepository
    {
        private readonly ApiContext context;
       
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="context">context</param>
        public UserRepository(ApiContext context)
            : base(context)
        {
            this.context = context;
        }

        /// <summary>
        /// obtener datos del usuario dado el login
        /// </summary>
        /// <param name="email"></param>
        /// <param name="pass"></param>
        /// <returns></returns>
        public Usuario GetUsuarioByLogin(string email, string pass)
        {
            return context.Usuarios.FirstOrDefault(a => a.Email == email && a.Pass == pass);
        }
    }
}
