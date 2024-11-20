using EventsWeb.BusinessLogic.Models.Participants;

namespace EventsWeb.BusinessLogic.UseCases.Participants
{
    public interface IGetParticipantsByPageUseCase
    {
        Task<IEnumerable<ParticipantResponseDto>> ExecuteAsync(int eventId, int page, int pageSize,
            CancellationToken cancellationToken);
    }
}
