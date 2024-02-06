using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class Respuestas
{
    public long IdEncuesta { get; set; }

    public long IdRespuesta { get; set; }

    public int IdPregunta { get; set; }

    public string? Valor { get; set; }

    public string? Observaciones { get; set; }

    public virtual NombreEncuesta IdEncuestaNavigation { get; set; } = null!;
}
