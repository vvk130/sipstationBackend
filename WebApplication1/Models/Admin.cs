using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Admin
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public string? Lastname { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<Restaurant> Restaurants { get; set; } = new List<Restaurant>();
}
