using Appointment.Booking.Domain.IRepositories;

namespace Appointment.Booking.Infrastructure.Repositories
{
    internal class AppointmentRepo : IAppointmentRepo
    {
        public Task<int> AddAppointment(Domain.Models.Appointment appointment)
        {
            throw new NotImplementedException();
        }
    }
}
