using EventsWeb.BusinessLogic.Models.Events;

namespace EventsWeb.BusinessLogic.UseCases.Events
{
    public interface IGetEventByIdUseCase
    {
        Task<EventResponseDto> ExecuteAsync(int id, CancellationToken cancellationToken);
    }
}
