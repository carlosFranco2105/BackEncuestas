using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class MailEncuestas
{
    public decimal IdMailEncuesta { get; set; }

    public decimal IdEncuesta { get; set; }

    public decimal IdFormatoMail { get; set; }

    public DateTime? FfDesde { get; set; }

    public DateTime? FfHasta { get; set; }

    public string? Query { get; set; }

    public virtual MailFormato IdMailEncuestaNavigation { get; set; } = null!;
}
