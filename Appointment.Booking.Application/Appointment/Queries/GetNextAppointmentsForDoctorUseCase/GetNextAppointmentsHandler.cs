using Appointment.Booking.Domain.IRepositories;
using AppointmentModel = Appointment.Booking.Domain.Models.Appointment;

namespace Appointment.Booking.Application.Appointment.Queries.GetNextAppointmentsForDoctorUseCase
{
    public class GetNextAppointmentsHandler
    {
        private readonly IAppointmentRepo _appointmentRepo;

        public GetNextAppointmentsHandler(IAppointmentRepo appointmentRepo)
        {
            _appointmentRepo = appointmentRepo;
        }

        public async Task<IEnumerable<AppointmentModel>> Handle(Guid doctorId)
        {
            return await _appointmentRepo.GetNextAppointmentsForDoctor(doctorId);
        }
    }
}
