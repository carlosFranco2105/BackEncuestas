using Entities.Models;

namespace Logic.IRepositories
{
    public interface IEstadisticaRepository
    {
        List<Estadistica> GetEstadistica();
    }
}