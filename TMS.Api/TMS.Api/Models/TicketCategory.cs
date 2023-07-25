using System;
using System.Collections.Generic;

namespace TMS.Api.Models;

public partial class TicketCategory
{
    public long TicketCategoryId { get; set; }

    public decimal Price { get; set; }

    public string Description { get; set; } = null!;

    public long EventId { get; set; }

    public virtual Event Event { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
