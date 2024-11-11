using EventsWeb.Domain.Repositories;

namespace EventsWeb.Domain
{
    public interface IUnitOfWork
    {
        public Task SaveChangesAsync(CancellationToken cancellationToken);
        public IEventRepository Events { get; }
        public IParticipantRepository Participants { get; }
    }
}

