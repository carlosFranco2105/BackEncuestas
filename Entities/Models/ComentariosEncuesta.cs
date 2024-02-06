using Entities.Models;
using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class ComentariosEncuesta
{
    public long IdEncuesta { get; set; }

    public decimal IdRespuesta { get; set; }

    public string? Comentario { get; set; }

    public virtual NombreEncuesta IdEncuestaNavigation { get; set; } = null!;
}
