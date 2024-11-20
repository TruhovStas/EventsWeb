using AutoMapper;
using EventsWeb.BusinessLogic.Models.Events;
using EventsWeb.Domain;

namespace EventsWeb.BusinessLogic.UseCases.Events.Impl
{
    public class GetEventsByPageUseCase : IGetEventsByPageUseCase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetEventsByPageUseCase(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EventResponseDto>> ExecuteAsync(int page, int pageSize, CancellationToken cancellationToken)
        {
            var events = await _unitOfWork.Events.GetByPageAsync(page, pageSize, cancellationToken);
            return _mapper.Map<IEnumerable<EventResponseDto>>(events);
        }
    }
}
