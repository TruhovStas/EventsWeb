using EventsWeb.BusinessLogic.Models.Participants;
using EventsWeb.BusinessLogic.UseCases.Participants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EventsWeb.Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ParticipantController : ControllerBase
    {
        private readonly ICreateParticipantUseCase _createParticipantUseCase;
        private readonly IDeleteParticipantUseCase _deleteParticipantUseCase;
        private readonly IGetParticipantByIdUseCase _getParticipantByIdUseCase;
        private readonly IGetParticipantsByEventUseCase _getParticipantsByEventUse;
        private readonly IGetParticipantsByPageUseCase _getParticipantsByPage;
        public ParticipantController(
            ICreateParticipantUseCase createParticipantUseCase,
            IDeleteParticipantUseCase deleteParticipantUseCase,
            IGetParticipantByIdUseCase getParticipantByIdUseCase,
            IGetParticipantsByEventUseCase getParticipantsByEventUse,
            IGetParticipantsByPageUseCase getParticipantsByPage
            )
        {
            _createParticipantUseCase = createParticipantUseCase;
            _deleteParticipantUseCase = deleteParticipantUseCase;
            _getParticipantByIdUseCase = getParticipantByIdUseCase;
            _getParticipantsByEventUse = getParticipantsByEventUse;
            _getParticipantsByPage = getParticipantsByPage;
        }

        [HttpGet("event/{eventId:int}")]
        public async Task<ActionResult<IEnumerable<ParticipantResponseDto>>> GetParticipantsByEvent(int eventId, CancellationToken cancellationToken)
        {
            return Ok(await _getParticipantsByEventUse.ExecuteAsync(eventId, cancellationToken));
        }

        [HttpGet("{page}/{pageSize}")]
        public async Task<ActionResult<IEnumerable<ParticipantResponseDto>>> GetParticipantsByPage(int eventId, int page, int pageSize,
            CancellationToken cancellationToken)
        {
            return Ok(await _getParticipantsByPage.ExecuteAsync(eventId, page, pageSize, cancellationToken));
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ParticipantResponseDto>> GetParticipantById(int id, CancellationToken cancellationToken)
        {
            return Ok(await _getParticipantByIdUseCase.ExecuteAsync(id, cancellationToken));
        }

        [Authorize(Policy = "AuthenticatedUser")]
        [HttpPost]
        public async Task<ActionResult<ParticipantCreateResponseDto>> CreateParticipant([FromForm] ParticipantCreateDto participantCreateDto,
            CancellationToken cancellationToken)
        {
            return Ok(await _createParticipantUseCase.ExecuteAsync(participantCreateDto, cancellationToken));
        }

        [Authorize(Policy = "AuthenticatedUser")]
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<ParticipantResponseDto>> DeleteParticipant(int id, CancellationToken cancellationToken)
        {
            return Ok(await _deleteParticipantUseCase.ExecuteAsync(id, cancellationToken));
        }
    }
}
