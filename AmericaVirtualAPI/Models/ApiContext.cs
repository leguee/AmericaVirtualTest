using Microsoft.EntityFrameworkCore;

namespace AmericaVirtualAPI.Models
{
    /// <summary>
    /// Db Context de la aplicacion
    /// </summary>
    public class ApiContext : DbContext
    {
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="options"></param>
        public ApiContext(DbContextOptions<ApiContext> options) : base(options)
        {
        }

        /// <summary>
        /// Dataset de productos
        /// </summary>
        public DbSet<Producto> Productos { get; set; }

        /// <summary>
        /// Dataset de usuarios
        /// </summary>
        public DbSet<Usuario> Usuarios{ get; set; }
        
        /// <summary>
        /// Dataset de Logs
        /// </summary>
        public DbSet<Log> Logs { get; set; }
    }
}
