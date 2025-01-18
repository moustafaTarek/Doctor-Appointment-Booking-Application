using System.Collections.Generic;
using AppointmentModel = Appointment.Booking.Domain.Models.Appointment;

namespace Appointment.Booking.Domain.IRepositories
{
    public interface IAppointmentRepo
    {
         Task<Guid> AddAppointment(AppointmentModel appointment);
         Task<bool> AppointmentExists(Guid appointmentId);
         Task <IEnumerable<AppointmentModel>> GetNextAppointmentsForDoctor(Guid doctorId);
    }
}
