using AmericaVirtualAPI.Helpers;
using AmericaVirtualAPI.Models;
using AmericaVirtualAPI.Services;
using Library.API.Helpers;
using Microsoft.AspNetCore.Mvc;
using System;

namespace AmericaVirtualAPI.Controllers
{
    /// <summary>
    /// Controlador de productos
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private IRepository<Producto> _productoRepository;
        private IUrlHelper _urlHelper;

        /// <summary>
        /// Constructor del controlador de productos
        /// </summary>
        /// <param name="productoRepository"></param>
        /// <param name="urlHelper"></param>
        public ProductosController(IRepository<Producto> productoRepository, IUrlHelper urlHelper)
        {
            _productoRepository = productoRepository;
            _urlHelper = urlHelper;
        }

        // GET api/Productos
        /// <summary>
        /// Obtener productos paginados
        /// </summary>
        /// <param name="resourceParameters">Parametros para paginación</param>
        /// <returns>Lista de productos</returns>
        [HttpGet(Name = "GetProductos")]
        public IActionResult GetProductos([FromQuery] EntitiesResourceParameters resourceParameters)
        {
            try
            {
                var productsFromRepo = _productoRepository.GetAll(resourceParameters);

                // genera el link de pagina previa en el paginado
                var previousPageLink = productsFromRepo.HasPrevious ?
                    CreateResourceUri(resourceParameters,
                    ResourceUriType.PreviousPage) : null;

                // genera link de pagina siguiente en el paginado
                var nextPageLink = productsFromRepo.HasNext ?
                    CreateResourceUri(resourceParameters,
                    ResourceUriType.NextPage) : null;

                // se generan los datos opcionales a mandar en Header (metadata)
                var paginationMetadata = new
                {
                    totalCount = productsFromRepo.TotalCount,
                    pageSize = productsFromRepo.PageSize,
                    currentPage = productsFromRepo.CurrentPage,
                    totalPages = productsFromRepo.TotalPages,
                    previousPageLink = previousPageLink,
                    nextPageLink = nextPageLink
                };

                Response.Headers.Add("X-Pagination",
                    Newtonsoft.Json.JsonConvert.SerializeObject(paginationMetadata));

                return Ok(productsFromRepo);

            }
            catch (Exception)
            {

                return StatusCode(500, "A problem happened with handling your request.");
            }
        }

        // POST api/productos
        /// <summary>
        /// Alta de producto
        /// </summary>
        /// <param name="value">Nuevo producto</param>
        /// <returns>Producto insertado</returns>
        [HttpPost]
        public IActionResult Post([FromBody]Producto value)
        {
            if (value == null)
            {
                return BadRequest();
            }
            
            _productoRepository.Add(value);

            if (!_productoRepository.Save())
            {
                return StatusCode(500, "A problem happened with handling your request.");
            }

            // devuelve el producto creado
            return CreatedAtRoute("GetProducto",
                new { id = value.Id },
                value);
        }

        // GET api/Productos/1
        /// <summary>
        /// Obtener producto dado su Id
        /// </summary>
        /// <param name="id">Id del producto</param>
        /// <returns>Producto encontrado</returns>
        [HttpGet("{id}", Name = "GetProducto")]
        public IActionResult GetProducto(long id)
        {
            var productoFromRepo = _productoRepository.GetById(id);

            if (productoFromRepo == null)
            {
                return NotFound();
            }
            
            return Ok(productoFromRepo);
        }
        
        // PUT api/productos/5
        /// <summary>
        /// Actualización de datos del producto
        /// </summary>
        /// <param name="id">Id del producto</param>
        /// <param name="value">Datos del producto a actualizar</param>
        /// <returns>Producto actualizado</returns>
        [HttpPut("{id}")]
        public IActionResult UpdateProducto(long id, Producto value)
        {
            if (id != value.Id)
            {
                return BadRequest();
            }
          
            _productoRepository.Update(value);

            if (!_productoRepository.Save())
            {
                return StatusCode(500, "A problem happened with handling your request.");
            }

            // devuelve el producto 
            return CreatedAtRoute("GetProducto",
                new { id = value.Id },
                value);
        }

        /// <summary>
        /// metodo de creacion de urls para paginado prev y next
        /// </summary>
        /// <param name="resourceParameters">Recursos del parametro</param>
        /// <param name="type">Tipo de uri</param>
        /// <returns>retorna link de paginado</returns>
        private string CreateResourceUri(
           EntitiesResourceParameters resourceParameters,
           ResourceUriType type)
        {
            switch (type)
            {
                case ResourceUriType.PreviousPage:
                    return _urlHelper.Link("GetProductos",
                      new
                      {
                          pageNumber = resourceParameters.PageNumber - 1,
                          pageSize = resourceParameters.PageSize
                      });
                case ResourceUriType.NextPage:
                    return _urlHelper.Link("GetProductos",
                      new
                      {
                          pageNumber = resourceParameters.PageNumber + 1,
                          pageSize = resourceParameters.PageSize
                      });

                default:
                    return _urlHelper.Link("GetProductos",
                    new
                    {
                        pageNumber = resourceParameters.PageNumber,
                        pageSize = resourceParameters.PageSize
                    });
            }
        }
    }
}