﻿using AutoMapper;
using EventsWeb.BusinessLogic.Exceptions;
using EventsWeb.BusinessLogic.Models;
using EventsWeb.BusinessLogic.Models.Participants;
using EventsWeb.DataAccess;
using EventsWeb.Domain.Entities;

namespace EventsWeb.BusinessLogic.Services.Impl
{
    public class ParticipantService : IParticipantService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ParticipantService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ParticipantResponseDto>> GetParticipantsAsync(CancellationToken cancellationToken)
        {
            var participants = await _unitOfWork.Participants.GetAllAsync(cancellationToken);
            return _mapper.Map<IEnumerable<ParticipantResponseDto>>(participants);
        }

        public async Task<IEnumerable<ParticipantResponseDto>> GetParticipantsByPageAsync(int page, int pageSize,
            CancellationToken cancellationToken)
        {
            var participants = await _unitOfWork.Participants.GetByPageAsync(page, pageSize, cancellationToken);
            return _mapper.Map<IEnumerable<ParticipantResponseDto>>(participants);
        }

        public async Task<ParticipantResponseDto> GetParticipantByIdAsync(int id, CancellationToken cancellationToken)
        {
            var ev = await _unitOfWork.Participants.GetByIdAsync(id, cancellationToken);
            if (ev == null)
                throw new NotFoundException("Participant not found");
            return _mapper.Map<ParticipantResponseDto>(ev);
        }

        public async Task<ParticipantCreateResponseDto> CreateParticipantAsync(ParticipantCreateDto participantCreateDto,
            CancellationToken cancellationToken)
        {
            var ev = _mapper.Map<Participant>(participantCreateDto);
            var createdParticipant = await _unitOfWork.Participants.AddAsync(ev, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return _mapper.Map<ParticipantCreateResponseDto>(createdParticipant);
        }

        public async Task<BaseResponseDto> DeleteParticipantAsync(int id, CancellationToken cancellationToken)
        {
            var ev = await _unitOfWork.Participants.GetByIdAsync(id, cancellationToken);
            if (ev == null)
                throw new NotFoundException("Participant not found");
            _unitOfWork.Participants.Delete(ev);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return new BaseResponseDto() { Id = id };
        }
    }
}
