namespace EventsWeb.BusinessLogic.DTOs.Participants
{
    public class ParticipantResponseDto : BaseResponseDTO
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateOnly BirthDay { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string Email { get; set; }
    }
}
