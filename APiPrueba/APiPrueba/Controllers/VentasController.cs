using Datos;
using Logica.Interface;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APiPrueba.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentasController : ControllerBase
    {
        IVentas _ventas;
        public VentasController(IVentas ventas)
        {
            _ventas = ventas;
        }

        // GET api/<VentasController>/5
        [HttpGet("{id}")]
        public object Get(int id)
        {
            return _ventas.GetVetas(id);
        }

        // POST api/<VentasController>
        [HttpPost]
        public object Post([FromBody] Ventum ventas)
        {
            return _ventas.SetVentaPost(ventas);
        }

        // DELETE api/<VentasController>/5
        [HttpDelete("{id}")]
        public object Delete(int id)
        {
           return _ventas.SetVentaDele(id);
        }
    }
}
