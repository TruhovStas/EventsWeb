using EventsWeb.BusinessLogic.Models.Events;

namespace EventsWeb.BusinessLogic.UseCases.Events
{
    public interface IGetEventsByPageUseCase
    {
        Task<IEnumerable<EventResponseDto>> ExecuteAsync(int page, int pageSize, CancellationToken cancellationToken);
    }
}
