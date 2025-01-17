namespace Integration.DTOs
{
    public class SlotGetResponse
    {
        public Guid SlotId { get; set; }
        public DateTimeOffset Time { get; set; }
        public Guid DoctorId { get; set; }
        public string DoctorName { get; set; }
        public bool IsReserved { get; set; }
        public double Cost { get; set; }
    }
}
