namespace Doctor.Appointment.Management.Core.Models
{
    public class AppointmentStatus
    {
        public AppointmentId AppointmentId { get; }

        public Status Status { get; }
        
        private AppointmentStatus(Guid appointmentId, short statusId)
        {
            AppointmentId = new (appointmentId);
            Status = new(statusId);            
        }

        public static AppointmentStatus Create(Guid AppointmentId, short AppointmentStatusId)
        {
            return new AppointmentStatus(AppointmentId, AppointmentStatusId);
        }
    }
}
