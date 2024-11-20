using AutoMapper;
using EventsWeb.BusinessLogic.Models.Participants;
using EventsWeb.Domain;
using EventsWeb.BusinessLogic.Exceptions;

namespace EventsWeb.BusinessLogic.UseCases.Participants.Impl
{
    public class GetParticipantByIdUseCase : IGetParticipantByIdUseCase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetParticipantByIdUseCase(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ParticipantResponseDto> ExecuteAsync(int id, CancellationToken cancellationToken)
        {
            var participant = await _unitOfWork.Participants.GetByIdAsync(id, cancellationToken);
            if (participant == null)
                throw new NotFoundException("Participant not found");
            return _mapper.Map<ParticipantResponseDto>(participant);
        }
    }
}
