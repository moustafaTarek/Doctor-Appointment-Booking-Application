namespace Doctor.Appointment.Management.Core.Models
{
    public class AppointmentId
    {
        public Guid Id { get; }

        public AppointmentId(Guid appointemnetId)
        {
            if( appointemnetId == null || appointemnetId == Guid.Empty)
                throw new ArgumentNullException(nameof(appointemnetId));

            Id = appointemnetId;
        }
    }
}
