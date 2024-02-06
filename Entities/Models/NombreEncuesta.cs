using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class NombreEncuesta
    {
        public long IdEncuesta { get; set; }

        public string Nombre { get; set; } = null!;

        public virtual ICollection<Estadistica> Estadisticas { get; } = new List<Estadistica>();

        public virtual IEnumerable<Respuesta> Respuesta { get; } = new List<Respuesta>();
    }
}


