namespace EventsWeb.BussinessLogic.DTOs.Participants
{
    internal class ParticipantListDto : BaseResponseDTO
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime RegistrationDate { get; set; }
    }
}
