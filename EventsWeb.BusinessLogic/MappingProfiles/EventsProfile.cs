using AutoMapper;
using EventsWeb.BusinessLogic.DTOs.Events;
using EventsWeb.BussinessLogic.DTOs.Events;
using EventsWeb.Domain.Entities;

namespace EventsWeb.BusinessLogic.MappingProfiles
{
    public class EventsProfile : Profile, IMappingProfile
    {
        public EventsProfile() 
        {
            CreateMap<Event, EventResponseDto>();
            CreateMap<Event, EventCreateResponseDto>();
            CreateMap<EventUpdateDto, Event>();
            CreateMap<EventCreateDto, Event>();
            CreateMap<Event, EventListResponseDto>();
        }
    }
}
