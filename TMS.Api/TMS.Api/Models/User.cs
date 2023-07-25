using System;
using System.Collections.Generic;

namespace TMS.Api.Models;

public partial class User
{
    public int CustomerId { get; set; }

    public string CustomerName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
