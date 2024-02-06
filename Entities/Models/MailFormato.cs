using Entities.Models;
using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class MailFormato
{
    public decimal IdMailFormato { get; set; }

    public string? MailSubject { get; set; }

    public string? MailBody { get; set; }

    public DateTime? FfBaja { get; set; }

    public virtual MailEncuestas? MailEncuesta { get; set; }
}
