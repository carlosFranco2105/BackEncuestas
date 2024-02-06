using Entities.Models;
using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class DatosDemografico
{
    public long IdEncuesta { get; set; }

    public long IdRespuesta { get; set; }

    public string? Edad { get; set; }

    public string? Genero { get; set; }

    public string? Provincia { get; set; }

    public string? Jurisdiccion { get; set; }

    public string? ConvColectivo { get; set; }

    public string? Estudios { get; set; }

    public string? Antiguedad { get; set; }

    public string? ComunicacionPuntoencuentro { get; set; }

    public string? ComunicacionSitiorrhh { get; set; }

    public string? ComunicacionIntranet { get; set; }

    public string? ComunicacionMail { get; set; }

    public string? ComunicacionInstitucionales { get; set; }

    public virtual NombreEncuesta IdEncuestaNavigation { get; set; } = null!;
}
