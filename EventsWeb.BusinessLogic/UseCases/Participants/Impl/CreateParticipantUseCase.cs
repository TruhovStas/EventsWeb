using AutoMapper;
using EventsWeb.BusinessLogic.Models.Events;
using EventsWeb.Domain.Entities;
using EventsWeb.Domain;
using EventsWeb.BusinessLogic.Models.Participants;
using Library.BusinessAccess.Exceptions;

namespace EventsWeb.BusinessLogic.UseCases.Participants.Impl
{
    public class CreateParticipantUseCase : ICreateParticipantUseCase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateParticipantUseCase(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ParticipantCreateResponseDto> ExecuteAsync(ParticipantCreateDto participantCreateDto, CancellationToken cancellationToken)
        {
            var participant = _mapper.Map<Participant>(participantCreateDto);
            participant.RegistrationDate = DateTime.Now;
            var ev = await _unitOfWork.Events.GetByIdAsync(participant.Event.Id, cancellationToken);
            if (ev.Participants != null && ev.Participants.Any(p => p.Email == participant.Email))
            {
                throw new AlreadyExistsException("You are already a participant of this event.");
            }
            var createdParticipant = await _unitOfWork.Participants.AddAsync(participant, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return _mapper.Map<ParticipantCreateResponseDto>(createdParticipant);
        }
    }
}
