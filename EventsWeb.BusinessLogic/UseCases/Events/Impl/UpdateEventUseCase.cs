using AutoMapper;
using EventsWeb.BusinessLogic.Models.Events;
using EventsWeb.Domain;
using EventsWeb.BusinessLogic.Exceptions;
using EventsWeb.BusinessLogic.Models;

namespace EventsWeb.BusinessLogic.UseCases.Events.Impl
{
    public class UpdateEventUseCase : IUpdateEventUseCase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateEventUseCase(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponseDto> ExecuteAsync(EventUpdateDto eventUpdateDto, CancellationToken cancellationToken)
        {
            var ev = await _unitOfWork.Events.GetByIdAsync(eventUpdateDto.Id, cancellationToken);
            if (ev == null)
                throw new NotFoundException("Event not found");
            _mapper.Map(eventUpdateDto, ev);
            var updatedEvent = _unitOfWork.Events.Update(ev);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return new BaseResponseDto() { Id = updatedEvent.Id };
        }
    }
}
