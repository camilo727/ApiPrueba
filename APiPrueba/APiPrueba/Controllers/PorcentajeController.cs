using Datos;
using Logica.Interface;
using Microsoft.AspNetCore.Mvc;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APiPrueba.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PorcentajeController : ControllerBase
    {
        IPorcentaje _porcentaje;
        public PorcentajeController(IPorcentaje porcentaje)
        {
            _porcentaje = porcentaje;
        }
        // GET: api/<PorcentajeController>
        [HttpGet]
        public IEnumerable<Procentaje> Get()
        {
            return _porcentaje.GetPorcentajes();
        }

        // GET api/<PorcentajeController>/5
        [HttpGet("{id}")]
        public Procentaje Get(int id)
        {
            return _porcentaje.GetProcentajeID(id);
        }

        // POST api/<PorcentajeController>
        [HttpPost]
        public object Post([FromBody] Procentaje procentaje)
        {
            return _porcentaje.SetPorcentajePost(procentaje);
        }

        // PUT api/<PorcentajeController>/5
        [HttpPut("{id}")]
        public object Put(int id, [FromBody] Procentaje procentaje)
        {
            return _porcentaje.SetPorcentajePut(id,procentaje);
        }

        // DELETE api/<PorcentajeController>/5
        [HttpDelete("{id}")]
        public object Delete(int id)
        {
            return _porcentaje.SetPorcentajeDele(id);
        }
    }
}
