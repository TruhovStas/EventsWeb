using AutoMapper;
using EventsWeb.BusinessLogic.Models.Participants;
using EventsWeb.Domain;

namespace EventsWeb.BusinessLogic.UseCases.Participants.Impl
{
    public class GetParticipantsByEventUseCase : IGetParticipantsByEventUseCase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetParticipantsByEventUseCase(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ParticipantResponseDto>> ExecuteAsync(int eventId, CancellationToken cancellationToken)
        {
            var participants = await _unitOfWork.Participants.GetAllAsync(cancellationToken);
            return _mapper.Map<IEnumerable<ParticipantResponseDto>>(participants.Where(p => p.Event.Id == eventId));
        }
    }
}
