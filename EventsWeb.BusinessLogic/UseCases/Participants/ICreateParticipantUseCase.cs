using EventsWeb.BusinessLogic.Models.Participants;

namespace EventsWeb.BusinessLogic.UseCases.Participants
{
    public interface ICreateParticipantUseCase
    {
        Task<ParticipantCreateResponseDto> CreateParticipantAsync(ParticipantCreateDto participantCreateDto, CancellationToken cancellationToken);
    }
}
