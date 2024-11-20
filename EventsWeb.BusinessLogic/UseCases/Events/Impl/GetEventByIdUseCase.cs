using AutoMapper;
using EventsWeb.BusinessLogic.Models.Events;
using EventsWeb.Domain;
using EventsWeb.BusinessLogic.Exceptions;

namespace EventsWeb.BusinessLogic.UseCases.Events.Impl
{
    public class GetEventByIdUseCase : IGetEventByIdUseCase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetEventByIdUseCase(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<EventResponseDto> ExecuteAsync(int id, CancellationToken cancellationToken)
        {
            var ev = await _unitOfWork.Events.GetByIdAsync(id, cancellationToken);
            if (ev == null)
                throw new NotFoundException("Event not found");
            return _mapper.Map<EventResponseDto>(ev);
        }
    }
}
