using TMS.Api.Models;

namespace TMS.Api.Repositories
{
    public interface IEventRepository
    {
        IEnumerable<Event> GetAll();

        Event GetById(long id);

        int Add(Event @event);

        void Update(Event @event);

        int Delete(long id);
    }
}
