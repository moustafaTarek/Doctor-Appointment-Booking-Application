using Appointment.Booking.Domain.Enums;

namespace Appointment.Booking.Domain.Models
{
    public class Appointment
    {
        public Guid Id { get;  }
        public Guid DoctorId { get; }
        public Guid PatientId { get;  }
        public Guid SlotId { get;  }
        public DateTimeOffset ReservedAt { get; }
        public AppointmentStatus Status { get; private set; }

        private Appointment(Guid doctorId, Guid patientId, Guid slotId)
        {
            Id = Guid.NewGuid();
            DoctorId = doctorId;
            PatientId = patientId;
            SlotId = slotId;
            ReservedAt = DateTimeOffset.UtcNow;
            Status = AppointmentStatus.Pending;
        }

        public static Appointment Create(Guid doctorId, Guid patientId, Guid slotId)
        {
            return new Appointment(doctorId, patientId, slotId);
        }

        public void UpdateStatus(AppointmentStatus appointmentStatus)
        {
            Status = appointmentStatus;
        }
    }
}