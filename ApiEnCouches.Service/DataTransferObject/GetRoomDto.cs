namespace ApiEnCouches.Service.DataTransferObject
{
    public class GetRoomDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Capacity { get; set; }
        public List<GetTimeslotDto> Timeslots { get; set; } = new List<GetTimeslotDto>();
    }
}