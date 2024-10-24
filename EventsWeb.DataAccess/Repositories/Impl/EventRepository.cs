using EventsWeb.Domain.Entities;

namespace EventsWeb.DataAccess.Repositories.Impl
{
    public class EventRepository : BaseRepository<Event>, IEventRepository
    {
        public EventRepository(DbContext context) : base(context) { }
    }
}
