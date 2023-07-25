using System;
using System.Collections.Generic;

namespace TMS.Api.Models;

public partial class Event
{
    public long EventId { get; set; }

    public string EventName { get; set; } = null!;

    public string EventDescription { get; set; } = null!;

    public long EventTypeId { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public long VenueId { get; set; }

    public virtual EventType? EventType { get; set; } = null!;

    public virtual ICollection<TicketCategory> TicketCategories { get; set; } = new List<TicketCategory>();

    public virtual Venue? Venue { get; set; } = null!;
}
