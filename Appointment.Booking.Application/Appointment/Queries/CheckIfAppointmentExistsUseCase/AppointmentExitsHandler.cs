using Appointment.Booking.Domain.IRepositories;

namespace Appointment.Booking.Application.Appointment.Queries.CheckIfAppointmentExistsUseCase
{
    public class AppointmentExitsHandler
    {
        private readonly IAppointmentRepo _appointmentRepo;

        public AppointmentExitsHandler(IAppointmentRepo appointmentRepo)
        {
            _appointmentRepo = appointmentRepo;
        }

        public async Task<bool> Handle(Guid AppointmentId)
        {
            return await _appointmentRepo.AppointmentExists(AppointmentId);
        }
    }
}
