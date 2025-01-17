using Appointment.Booking.Domain.IRepositories;
using Integration.Events;
using MediatR;

namespace Appointment.Booking.Application.Appointment.Queries.CheckIfAppointmentExistsUseCase
{
    internal class AppointmentExitsHandler : IRequestHandler<AppointmentExistsQueryEvent, bool>
    {
        private readonly IAppointmentRepo _appointmentRepo;

        public AppointmentExitsHandler(IAppointmentRepo appointmentRepo)
        {
            _appointmentRepo = appointmentRepo;
        }

        public async Task<bool> Handle(AppointmentExistsQueryEvent request, CancellationToken cancellationToken)
        {
            return await _appointmentRepo.AppointmentExists(request.Id);
        }
    }
}
