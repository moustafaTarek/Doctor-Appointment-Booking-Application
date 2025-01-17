using Appointment.Booking.Domain.IRepositories;
using Integration.DTOs;
using Integration.Events;
using MediatR;

namespace Appointment.Booking.Application.Appointment.Queries.GetNextAppointmentsForDoctorUseCase
{
    internal class GetNextAppointmentsHandler : IRequestHandler<AppointmentsGetQueryEvent, IList<AppointmentGetQueryResponse>>
    {
        private readonly IAppointmentRepo _appointmentRepo;

        public GetNextAppointmentsHandler(IAppointmentRepo appointmentRepo)
        {
            _appointmentRepo = appointmentRepo;
        }

        public async Task<IList<AppointmentGetQueryResponse>> Handle(AppointmentsGetQueryEvent request, CancellationToken cancellationToken)
        {
            var aapointments = await _appointmentRepo.GetNextAppointmentsForDoctor(request.DoctorId);

            return aapointments.Select(a => new AppointmentGetQueryResponse
            {
                Id = a.Id,
                DoctorId = a.DoctorId,
                PatientId = a.PatientId,
                SlotId = a.SlotId,
                ReservedAt = a.ReservedAt,
                Status = a.Status.ToString()
            }).ToList();
        }
    }
}