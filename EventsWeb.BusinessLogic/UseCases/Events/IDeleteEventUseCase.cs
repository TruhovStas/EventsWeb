using EventsWeb.BusinessLogic.Models;

namespace EventsWeb.BusinessLogic.UseCases.Events
{
    public interface IDeleteEventUseCase
    {
        Task<BaseResponseDto> ExecuteAsync(int id, CancellationToken cancellationToken);
    }
}
