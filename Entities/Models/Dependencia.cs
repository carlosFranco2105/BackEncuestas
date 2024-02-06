using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class Dependencia
{
    public int Nodo { get; set; }

    public string Nombre { get; set; } = null!;

    public long Cuit { get; set; }

    public string? Contacto { get; set; }
}
