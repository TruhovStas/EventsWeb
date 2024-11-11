using EventsWeb.BusinessLogic.Models.Events;
using EventsWeb.BusinessLogic.Models;

namespace EventsWeb.BusinessLogic.UseCases.Events
{
    public interface IUpdateEventUseCase
    {
        Task<BaseResponseDto> ExecuteAsync(EventUpdateDto eventUpdateDto, CancellationToken cancellationToken);
    }
}
