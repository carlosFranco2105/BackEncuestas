using Entities.Models;
using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class Estadistica
{
    public long IdEncuesta { get; set; }

    public long IdRespuesta { get; set; }

    public string? FechaHora { get; set; }

    public decimal? DesdeWeb { get; set; }

    public decimal? DesdeIntranet { get; set; }

    public string? Plataforma { get; set; }

    public virtual NombreEncuesta IdEncuestaNavigation { get; set; } = null!;
}
