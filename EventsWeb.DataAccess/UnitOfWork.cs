using EventsWeb.DataAccess.Repositories.Impl;
using EventsWeb.Domain.Repositories;
using EventsWeb.Domain;

namespace EventsWeb.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private DatabaseContext _dbContext;
        private IEventRepository _eventRepository;
        private IParticipantRepository _participantRepository;

        public UnitOfWork(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEventRepository Events
        {
            get
            {
                if (_eventRepository == null)
                    _eventRepository = new EventRepository(_dbContext);
                return _eventRepository;
            }
        }

        public IParticipantRepository Participants
        {
            get
            {
                if (_participantRepository == null)
                    _participantRepository = new ParticipantRepository(_dbContext);
                return _participantRepository;
            }
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        private bool _disposed = false;
        public virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
                _disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
