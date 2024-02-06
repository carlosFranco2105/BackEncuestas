using Data;
using Entities.Models;
using Logic.IRepositories;
using Logic.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Services
{
    public class NombreEncuestaService : INombreEncuestaService
    {
        //private readonly INombreEncuestaRepository _nombreEncuestaRepository;
        private readonly ModelContext? _modelContext;

        public NombreEncuestaService(ModelContext? modelContext)
        {
            _modelContext = modelContext;
        }

        public List<NombreEncuesta> GetNombreEncuestas()
        {
            return _modelContext.NombreEncuesta.ToList();
        }

        //public NombreEncuestaService(INombreEncuestaRepository nombreEncuestaRepository)
        //{
        //    _nombreEncuestaRepository = nombreEncuestaRepository;
        //}


        ////private readonly ITransactionQuery _transactionQuery;
        //private readonly IEntityQuery<NombreEncuesta> _userQuery;

        //public NombreEncuestaService(
        //               IEntityQuery<NombreEncuesta> entityQuery)
        //{
        //    //_transactionQuery = transactionQuery;
        //    _userQuery = entityQuery;
        //}

        //public ICollection<Estadistica> Estadisticas => throw new NotImplementedException();

        //public long IdEncuesta { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        //public string Nombre { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        //public ICollection<Respuesta> Respuesta => throw new NotImplementedException();

        //public List<NombreEncuesta> getAll()
        //{

        //    throw new NotImplementedException();
        //}

        //public List<NombreEncuesta> GetNombreEncuestas()
        //{
        //    var nombresEncuestas = _userQuery.GetAll();
        //    return nombresEncuestas.ToList();
        //}
        //public List<UserItem> GetUsersByCriteria(Expression<Func<UserItem, bool>> funcPred)
        //{
        //    var users = _userQuery.GetByCriteria(funcPred);
        //    return users.ToList();
        //}

    }
}
