using EventsWeb.BusinessLogic.Models;

namespace EventsWeb.BusinessLogic.UseCases.Participants
{
    public interface IDeleteParticipantUseCase
    {
        public Task<BaseResponseDto> ExecuteAsync(int id, CancellationToken cancellationToken);
    }
}
