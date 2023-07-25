using System;
using System.Collections.Generic;

namespace TMS.Api.Models;

public partial class Venue
{
    public int VenueId { get; set; }

    public string Location { get; set; } = null!;

    public string? Type { get; set; }

    public int Capacity { get; set; }

    public virtual ICollection<Event> Events { get; set; } = new List<Event>();
}
