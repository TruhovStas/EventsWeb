using EventsWeb.BusinessLogic.Services.Impl;
using EventsWeb.BusinessLogic.Services;
using Microsoft.Extensions.DependencyInjection;
using EventsWeb.BusinessLogic.UseCases.Events;
using EventsWeb.BusinessLogic.UseCases.Events.Impl;
using EventsWeb.BusinessLogic.UseCases.Participants;
using EventsWeb.BusinessLogic.UseCases.Participants.Impl;

namespace EventsWeb.BusinessLogic
{
    public static class BLDependencyInjection
    {
        public static IServiceCollection AddBLDependencyInjection(this IServiceCollection services) 
        {
            services.AddTransient<IFileService, FileService>();
            services.AddTransient<ITokenService, TokenService>();
            services.AddTransient<IUserService, UserService>();

            services.AddTransient<ICreateEventUseCase, CreateEventUseCase>();
            services.AddTransient<IDeleteEventUseCase, DeleteEventUseCase>();
            services.AddTransient<IGetEventByIdUseCase, GetEventByIdUseCase>();
            services.AddTransient<IGetEventsByPageUseCase, GetEventsByPageUseCase>();
            services.AddTransient<IGetEventsUseCase, GetEventsUseCase>();
            services.AddTransient<IUpdateEventUseCase, UpdateEventUseCase>();

            services.AddTransient<ICreateParticipantUseCase, CreateParticipantUseCase>();
            services.AddTransient<IDeleteParticipantUseCase, DeleteParticipantUseCase>();
            services.AddTransient<IGetParticipantByIdUseCase, GetParticipantByIdUseCase>();
            services.AddTransient<IGetParticipantsByEventUseCase, GetParticipantsByEventUseCase>();
            services.AddTransient<IGetParticipantsByPageUseCase, GetParticipantsByPageUseCase>();

            return services;
        }
    }
}
