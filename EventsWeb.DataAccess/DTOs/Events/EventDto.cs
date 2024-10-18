namespace EventsWeb.DataAccess.DTOs.Events
{
    public class EventDto : BaseResponseDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateTime { get; set; }
        public string Location { get; set; }
        public string? Category { get; set; }
        public int MaxParticipants { get; set; }
        public List<string>? Participants { get; set; }
        public string? Image { get; set; }
    }
}
