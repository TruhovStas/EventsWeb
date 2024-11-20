using EventsWeb.BusinessLogic.Models;
using EventsWeb.BusinessLogic.Models.Events;
using EventsWeb.BusinessLogic.UseCases.Events;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EventsWeb.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly ICreateEventUseCase _createEventUseCase;
        private readonly IDeleteEventUseCase _deleteEventUseCase;
        private readonly IGetEventByIdUseCase _getEventByIdUseCase;
        private readonly IGetEventsByPageUseCase _getEventsByPageUseCase;
        private readonly IGetEventsUseCase _getEventsUseCase;
        private readonly IUpdateEventUseCase _updateEventUseCase;

        public EventController(
            ICreateEventUseCase createEventUseCase,
            IDeleteEventUseCase deleteEventUseCase,
            IGetEventByIdUseCase getEventByIdUseCase,
            IGetEventsByPageUseCase getEventsByPageUseCase,
            IGetEventsUseCase getEventsUseCase,
            IUpdateEventUseCase updateEventUseCase
            )
        {
            _createEventUseCase = createEventUseCase;
            _deleteEventUseCase = deleteEventUseCase;
            _getEventByIdUseCase = getEventByIdUseCase;
            _getEventsByPageUseCase = getEventsByPageUseCase;
            _getEventsUseCase = getEventsUseCase;
            _updateEventUseCase = updateEventUseCase;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventResponseDto>>> GetEvents(CancellationToken cancellationToken)
        {
            return Ok(await _getEventsUseCase.ExecuteAsync(cancellationToken));
        }

        [HttpGet("{page}/{pageSize}")]
        public async Task<ActionResult<IEnumerable<EventResponseDto>>> GetEventsByPage(int page, int pageSize,
        CancellationToken cancellationToken)
        {
            return Ok(await _getEventsByPageUseCase.ExecuteAsync(page, pageSize, cancellationToken));
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<EventResponseDto>> GetEventById(int id, CancellationToken cancellationToken)
        {
            return Ok(await _getEventByIdUseCase.ExecuteAsync(id, cancellationToken));
        }

        [Authorize(Policy = "AuthenticatedUser")]
        [HttpPost]
        public async Task<ActionResult<EventCreateResponseDto>> CreateEvent([FromForm] EventCreateDto ev,
            CancellationToken cancellationToken)
        {
            return Ok(await _createEventUseCase.ExecuteAsync(ev, cancellationToken));
        }

        [Authorize(Policy = "AuthenticatedUser")]
        [HttpPut]
        public async Task<ActionResult<BaseResponseDto>> UpdateEvent([FromForm] EventUpdateDto ev,
            CancellationToken cancellationToken)
        {
            return Ok(await _updateEventUseCase.ExecuteAsync(ev, cancellationToken));
        }

        [Authorize(Policy = "AuthenticatedUser")]
        [HttpDelete("{id}")]
        public async Task<ActionResult<BaseResponseDto>> DeleteEvent(int id, CancellationToken cancellationToken)
        {
            return Ok(await _deleteEventUseCase.ExecuteAsync(id, cancellationToken));
        }
    }
}
