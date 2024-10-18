namespace EventsWeb.DataAccess.DTOs.Events
{
    public class EventListDto : BaseResponseDTO
    {
        public string Title { get; set; }
        public DateTime DateTime { get; set; }
        public string Location { get; set; }
        public string Category { get; set; }
        public string? Image { get; set; }
    }
}
