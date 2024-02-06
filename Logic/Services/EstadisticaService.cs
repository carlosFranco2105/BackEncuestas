using Data;
using Entities.Models;
using Logic.IRepositories;
using Logic.IServices;

namespace Logic.Services
{
    public class EstadisticaService : IEstadisticaService
    {
        //private readonly IEstadisticaRepository _estadisticaRepository;
        
        private readonly ModelContext? _modelContext;

        public EstadisticaService(ModelContext? modelContext)
        {
            _modelContext = modelContext;
        }

        public List<Estadistica> GetEstadisticas()
        {
            return _modelContext.Estadisticas.ToList();
        }
    }
}
