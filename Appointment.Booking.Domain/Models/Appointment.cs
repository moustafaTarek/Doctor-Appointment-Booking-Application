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

        private Appointment(Guid id, Guid doctorId, Guid patientId, Guid slotId, DateTimeOffset reservedAt, AppointmentStatus status)
        {
            Id = id;
            DoctorId = doctorId;
            PatientId = patientId;
            SlotId = slotId;
            ReservedAt = reservedAt;
            Status = status;
        }

        public static Appointment Create(Guid doctorId, Guid patientId, Guid slotId)
        {
            return new Appointment(doctorId, patientId, slotId);
        }

        public static Appointment Create(Guid id, Guid doctorId, Guid patientId, Guid slotId, DateTimeOffset reservedAt, AppointmentStatus status)
        {
            return new Appointment(id, doctorId, patientId, slotId, reservedAt, status);
        }

        public void UpdateStatus(AppointmentStatus appointmentStatus)
        {
            Status = appointmentStatus;
        }
    }
}