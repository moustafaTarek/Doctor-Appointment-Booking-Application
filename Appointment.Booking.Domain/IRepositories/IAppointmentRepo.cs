using AppointmentModel = Appointment.Booking.Domain.Models.Appointment;

namespace Appointment.Booking.Domain.IRepositories
{
    public interface IAppointmentRepo
    {
         Task<int> AddAppointment(AppointmentModel appointment);
    }
}
