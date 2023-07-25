using System;
using System.Collections.Generic;

namespace TMS.Api.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public decimal TotalPrice { get; set; }

    public int NumberOfTickets { get; set; }

    public DateTime OrderedAt { get; set; }

    public int TicketCategoryId { get; set; }

    public int CustomerId { get; set; }

    public virtual User Customer { get; set; } = null!;

    public virtual TicketCategory TicketCategory { get; set; } = null!;
}
