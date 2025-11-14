namespace ApiEnCouches.DataAccess.Entity
{
    public class Room
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;
        public int Capacity { get; set; }
        public List<TimeSlot> Timeslots { get; set; } = new List<TimeSlot>();
    }
}