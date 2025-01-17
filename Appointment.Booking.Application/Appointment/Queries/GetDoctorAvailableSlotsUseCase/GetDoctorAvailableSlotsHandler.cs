using Integration.DTOs;
using Integration.Events;
using Integration.Interfaces;
using MediatR;

namespace Appointment.Booking.Application.Appointment.Queries.GetDoctorAvailableSlotsUseCase
{
    public class GetDoctorAvailableSlotsHandler : IRequestHandler<DoctorAvailableSlotsQueryEvent, DoctorAvailableSlotsResponse>
    {
        private readonly IDoctorAvailabilityAPI _doctorAvailabilityService;

        private const int ZERO_AVAILABLE_SLOTS = 0;

        public GetDoctorAvailableSlotsHandler(IDoctorAvailabilityAPI doctorAvailabilityService)
        {
            _doctorAvailabilityService = doctorAvailabilityService;
        }

        public async Task<DoctorAvailableSlotsResponse> Handle(DoctorAvailableSlotsQueryEvent request, CancellationToken cancellationToken)
        {
            var slots = await _doctorAvailabilityService.GetAllUnreservedSlotsForDoctor(request.DoctorId);

            if (slots is null || slots.Count() == ZERO_AVAILABLE_SLOTS)
                throw new ArgumentNullException($"No available slots for doctor with Id: {request.DoctorId}", "Slots");

            return new DoctorAvailableSlotsResponse(slots);
        }
    }
}