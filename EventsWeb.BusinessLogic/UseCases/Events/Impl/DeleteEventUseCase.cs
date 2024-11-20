using EventsWeb.Domain;
using EventsWeb.BusinessLogic.Exceptions;
using EventsWeb.BusinessLogic.Models;

namespace EventsWeb.BusinessLogic.UseCases.Events.Impl
{
    public class DeleteEventUseCase : IDeleteEventUseCase
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteEventUseCase(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseResponseDto> ExecuteAsync(int id, CancellationToken cancellationToken)
        {
            var ev = await _unitOfWork.Events.GetByIdAsync(id, cancellationToken);
            if (ev == null)
                throw new NotFoundException("Event not found");
            _unitOfWork.Events.Delete(ev);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return new BaseResponseDto() { Id = id };
        }
    }
}
