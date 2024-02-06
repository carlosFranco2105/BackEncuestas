using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Logic.IRepositories;
using Logic.IServices;
namespace ApiEncuesta.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadisticaController : ControllerBase
    {
        //private readonly IEstadisticaRepository _estadisticaService;
        private readonly IEstadisticaService _estadisticaService;
        //public EstadisticaController(IEstadisticaRepository estadisticaService)
        //{
        //    _estadisticaService = estadisticaService;
        //}

        public EstadisticaController(IEstadisticaService estadisticaService)
        {
            _estadisticaService = estadisticaService;
        }

        [HttpGet(Name = "GetEstadistica")]
        public List<Estadistica> GetEstadistica()
        {
            return _estadisticaService.GetEstadisticas();
        }
    }
}
