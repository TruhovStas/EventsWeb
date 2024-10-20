namespace EventsWeb.BussinessLogic.DTOs.Events
{
    public class EventUpdateDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateTime { get; set; }
        public string Location { get; set; }
        public string? Category { get; set; }
        public int MaxParticipants { get; set; }
        public string? Image { get; set; }
    }
}
