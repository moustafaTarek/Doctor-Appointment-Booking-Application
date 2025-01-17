namespace Integration.DTOs
{
    public class AppointmentGetQueryResponse
    {
        public Guid Id { get; set; }
        public Guid DoctorId { get; set; }
        public Guid PatientId { get; set; }
        public Guid SlotId { get; set; }
        public DateTimeOffset ReservedAt { get; set; }
        public string Status { get; set; }
    }
}