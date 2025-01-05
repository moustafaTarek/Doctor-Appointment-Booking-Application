namespace Doctor.Availability.Core.Dtos.SlotDtos
{
    public class SlotAddRequest
    {
        public double Cost { get; set; }
        public DateTimeOffset Time { get; set; }
    }
}