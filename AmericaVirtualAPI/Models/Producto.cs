namespace AmericaVirtualAPI.Models
{
    /// <summary>
    /// Datos del producto
    /// </summary>
    public class Producto : Entidad
    {
        /// <summary>
        /// Titulo principal del producto
        /// </summary>
        public string Titulo { get; set; }

        /// <summary>
        /// Descripcion del producto
        /// </summary>
        public string Descripcion { get; set; }

        /// <summary>
        /// estado de vigencia del producto
        /// </summary>
        public string Estado { get; set; }

        /// <summary>
        /// precio del producto
        /// </summary>
        public long Precio { get; set; }

        /// <summary>
        /// Imagen principal del producto
        /// </summary>
        public string UrlImagen { get; set; }
    }
}
