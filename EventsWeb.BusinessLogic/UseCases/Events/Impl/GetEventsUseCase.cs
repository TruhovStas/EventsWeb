using AutoMapper;
using EventsWeb.BusinessLogic.Models.Events;
using EventsWeb.Domain;

namespace EventsWeb.BusinessLogic.UseCases.Events.Impl
{
    public class GetEventsUseCase : IGetEventsUseCase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetEventsUseCase(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EventResponseDto>> ExecuteAsync(CancellationToken cancellationToken)
        {
            var events = await _unitOfWork.Events.GetAllAsync(cancellationToken);
            return _mapper.Map<IEnumerable<EventResponseDto>>(events);
        }
    }
}
