using MediatR;

namespace Integration.Events
{
    public class AppointmentReservationCommandEvent : IRequest<string>
    {
        public Guid DoctorId { get; set; }
        public Guid PatientId { get; set; }
        public Guid SlotId { get; set; }
    }
}
