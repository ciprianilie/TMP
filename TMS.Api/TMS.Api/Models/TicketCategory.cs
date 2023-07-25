using System;
using System.Collections.Generic;

namespace TMS.Api.Models;

public partial class TicketCategory
{
    public int TicketCategoryId { get; set; }

    public decimal Price { get; set; }

    public string Description { get; set; } = null!;

    public int EventId { get; set; }

    public virtual Event Event { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
