using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class UserItem
{
    public decimal Id { get; set; }

    public string Username { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public DateTime? ExpiredAt { get; set; }
    public string DisplayName { get; set; } = null!;

    public string? Role { get; set; }
}