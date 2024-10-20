using AutoMapper;
using EventsWeb.BusinessLogic.DTOs.Participants;
using EventsWeb.Domain.Entities;

namespace EventsWeb.BusinessLogic.MappingProfiles
{
    public class ParticipantsProfile : Profile, IMappingProfile
    {
        public ParticipantsProfile() 
        {
            CreateMap<CreateParticipantDto, Participant>();
            CreateMap<Participant, CreateParticipantResponseDto>();
            CreateMap<Participant, ParticipantResponseDto>();
        }
    }
}
