using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Logic;
using System.Configuration;
using Logic.IRepositories;
using Logic.IServices;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiEncuesta.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NombreEncuestaController : ControllerBase

    {
        //private readonly ILogger<UserController> _logger;
        //private readonly IUserLogic _userLogic;        
        //private readonly INombreEncuestaRepository _nombreEncuestaService;
        private readonly INombreEncuestaService _nombreEncuestaService;
        //public NombreEncuestaController(INombreEncuestaRepository nombreEncuestaService)
        //{
        //    _nombreEncuestaService = nombreEncuestaService;
        //}

        public NombreEncuestaController(INombreEncuestaService nombreEncuestaService)
        {
            _nombreEncuestaService = nombreEncuestaService;
        }

        [HttpGet(Name = "GetNombresEncuestas")]
        public List<NombreEncuesta> GetNombres()
        {
            return _nombreEncuestaService.GetNombreEncuestas();
        }
        // GET: api/<Ecuesta>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}


        //// GET api/<Ecuesta>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<Ecuesta>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<Ecuesta>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<Ecuesta>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
