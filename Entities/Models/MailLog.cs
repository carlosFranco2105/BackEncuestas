using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class MailLog
{
    public decimal IdEncuesta { get; set; }

    public decimal Cantidad { get; set; }

    public DateTime FfEnvio { get; set; }
}
