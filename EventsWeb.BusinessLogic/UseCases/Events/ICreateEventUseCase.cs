using EventsWeb.BusinessLogic.Models.Events;

namespace EventsWeb.BusinessLogic.UseCases.Events
{
    public interface ICreateEventUseCase
    {
        Task<EventCreateResponseDto> ExecuteAsync(EventCreateDto eventCreateDto, CancellationToken cancellationToken)
    }
}
