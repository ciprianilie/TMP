using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TMS.Api.Models;

namespace TMS.Api.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly TmsTestContext _dbContext;

        public EventRepository()
        {
            _dbContext = new TmsTestContext();
        }

        public int Add(Event @event)
        {
            throw new NotImplementedException();
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Event> GetAll()
        {
            var events = _dbContext.Events;

            return events;
        }

        public Event GetById(int id)
        {
            var @event = _dbContext.Events.Where(e => e.EventId == id).FirstOrDefault();

            return @event;
        }

        public void Update(Event @event)
        {
            throw new NotImplementedException();
        }
    }
}
