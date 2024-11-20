using EventsWeb.BusinessLogic.Models.Participants;

namespace EventsWeb.BusinessLogic.UseCases.Participants
{
    public interface ICreateParticipantUseCase
    {
        Task<ParticipantCreateResponseDto> ExecuteAsync(ParticipantCreateDto participantCreateDto, CancellationToken cancellationToken);
    }
}
