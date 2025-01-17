using Doctor.Appointment.Management.Shell.Entities.Base;

namespace Doctor.Appointment.Management.Shell.Entities
{
    public class AppointmentStatus : BaseEntity<Guid>
    {
        public short StatusId { get; set; }
        public Status Status { get; set; }

        public Guid AppointmentId { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
    }
}