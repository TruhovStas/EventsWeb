using EventsWeb.Domain;
using EventsWeb.BusinessLogic.Exceptions;
using EventsWeb.BusinessLogic.Models;

namespace EventsWeb.BusinessLogic.UseCases.Participants.Impl
{
    public class DeleteParticipantUseCase : IDeleteParticipantUseCase
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteParticipantUseCase(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseResponseDto> ExecuteAsync(int id, CancellationToken cancellationToken)
        {
            var participant = await _unitOfWork.Participants.GetByIdAsync(id, cancellationToken);
            if (participant == null)
                throw new NotFoundException("Participant not found");
            _unitOfWork.Participants.Delete(participant);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return new BaseResponseDto() { Id = id };
        }
    }
}
