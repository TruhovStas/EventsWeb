namespace EventsWeb.BusinessLogic.DTOs.Participants
{
    public class CreateParticipantDto
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateOnly BirthDay { get; set; }
        public string Email { get; set; }
        public int EventId { get; set; }
    }
}
