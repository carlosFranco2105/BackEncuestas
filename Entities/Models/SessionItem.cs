using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class SessionItem
{
    public decimal Id { get; set; }
    public decimal UserId { get; set; }
    public virtual UserItem? User { get; set; }
    public DateTime OpenedAt { get; set; }
}
