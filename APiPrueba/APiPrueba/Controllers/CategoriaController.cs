using Datos;
using Logica.Interface;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APiPrueba.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        ICategoria _categoria;
        public CategoriaController(ICategoria categoria)
        {
            _categoria = categoria;
        }

        // GET: api/<CategoriaController>
        [HttpGet]
        public IEnumerable<Categorium> Get()
        {
            return _categoria.GetCategoria();
        }

        // GET api/<CategoriaController>/5
        [HttpGet("{id}")]
        public Categorium Get(int id)
        {
            return _categoria.GetCategorium(id);
        }

        // POST api/<CategoriaController>
        [HttpPost]
        public void Post([FromBody] Categorium Categoria)
        {
            _categoria.SetCategoria(Categoria);
        }

        // PUT api/<CategoriaController>/5
        [HttpPut("{id}")]
        public void Put(int id , [FromBody] Categorium Categoria)
        {
            _categoria.SetCategoriPut(id,Categoria);
        }

        //// DELETE api/<CategoriaController>/5
        [HttpDelete("{id}")]
        public object Delete(int id)
        {
           return _categoria.SetCategoriDele(id);
        }
    }
}
