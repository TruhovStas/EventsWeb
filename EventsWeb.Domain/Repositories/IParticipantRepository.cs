using EventsWeb.Domain.Entities;

namespace EventsWeb.Domain.Repositories
{
    public interface IParticipantRepository : IBaseRepository<Participant>
    {
        public Task<IEnumerable<Participant>?> GetListByEventAsync(int eventId, CancellationToken cancellationToken);
    }
}
