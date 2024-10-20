﻿namespace EventsWeb.BussinessLogic.DTOs.Events
{
    public class EventListResponseDto : BaseResponseDTO
    {
        public string Title { get; set; }
        public DateTime DateTime { get; set; }
        public string Location { get; set; }
        public string Category { get; set; }
        public string? Image { get; set; }
    }
}
