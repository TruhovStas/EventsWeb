using EventsWeb.BusinessLogic.Models.Participants;

namespace EventsWeb.BusinessLogic.UseCases.Participants
{
    public interface IGetParticipantByIdUseCase
    {
        public Task<ParticipantResponseDto> ExecuteAsync(int id, CancellationToken cancellationToken);
    }
}
