namespace EventsWeb.BussinessLogic.DTOs.Participants
{
    internal class ParticipantDto : BaseResponseDTO
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateOnly BirthDay { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string Email { get; set; }
    }
}
