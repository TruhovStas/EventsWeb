using AutoMapper;
using EventsWeb.BusinessLogic.Models.Events;
using EventsWeb.Domain;
using EventsWeb.Domain.Entities;

namespace EventsWeb.BusinessLogic.UseCases.Events.Impl
{
    public class CreateEventUseCase : ICreateEventUseCase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        
        public CreateEventUseCase(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<EventCreateResponseDto> ExecuteAsync(EventCreateDto eventCreateDto, CancellationToken cancellationToken)
        {
            var ev = _mapper.Map<Event>(eventCreateDto);
            var createdEvent = await _unitOfWork.Events.AddAsync(ev, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return _mapper.Map<EventCreateResponseDto>(createdEvent);
        }
    }
}
