using EventsWeb.Domain.Entities;
using EventsWeb.Domain.Repositories;

namespace EventsWeb.DataAccess.Repositories.Impl
{
    public class EventRepository : BaseRepository<Event>, IEventRepository
    {
        public EventRepository(DatabaseContext context) : base(context) { }
    }
}
