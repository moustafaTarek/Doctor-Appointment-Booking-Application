using Appointment.Booking.Infrastructure.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment.Booking.Infrastructure.Entities
{
    internal class AppointmentEntity : BaseEntity<Guid>
    {
        public Guid DoctorId { get; set; }
        public Guid SlotId { get; set; }
        public Guid PatientId { get; set; }
        public PatientEntity Patient { get; set; }
        public DateTimeOffset ReservedAt { get; set; }
        public short StatusId { get; set; }
    }
}
