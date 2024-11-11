using EventsWeb.BusinessLogic.Models.Events;

namespace EventsWeb.BusinessLogic.UseCases.Events
{
    public interface IGetEventsUseCase
    {
        Task<IEnumerable<EventResponseDto>> ExecuteAsync(CancellationToken cancellationToken);
    }
}
