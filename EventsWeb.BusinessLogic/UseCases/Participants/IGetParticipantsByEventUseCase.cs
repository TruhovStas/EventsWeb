using EventsWeb.BusinessLogic.Models.Participants;

namespace EventsWeb.BusinessLogic.UseCases.Participants
{
    public interface IGetParticipantsByEventUseCase
    {
        Task<IEnumerable<ParticipantResponseDto>> ExecuteAsync(int eventId, CancellationToken cancellationToken);
    }
}
