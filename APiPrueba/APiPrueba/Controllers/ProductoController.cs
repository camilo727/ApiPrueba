using Datos;
using Logica.Interface;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APiPrueba.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        IProducto  _producto;
        public ProductoController(IProducto producto)
        {
            _producto = producto;
        }


        // GET: api/<ProductoController>
        [HttpGet]
        public IEnumerable<Producto> Get()
        {
            return _producto.GetProductos();
        }

        // GET api/<ProductoController>/5
        [HttpGet("{id}")]
        public object Get(int id)
        {
            return _producto.GetProductoId(id);
        }

        // POST api/<ProductoController>
        [HttpPost]
        public object Post([FromBody] Producto producto)
        {
            return _producto.SetProductoPut(producto);
        }

        // PUT api/<ProductoController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE api/<ProductoController>/5
        [HttpDelete("{id}")]
        public object Delete(int id)
        {
            return _producto.SetProductoDele(id);
        }
    }
}
