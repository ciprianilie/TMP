namespace TMS.Api.Models.Dto
{
    public class EventDto
    {
        public long EventId { get; set; }

        public string EventName { get; set; } = string.Empty;

        public string EventDescription { get; set; }

        public string EventType { get; set; }

        public string Venue { get; set; }

    }
}
