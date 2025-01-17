using Integration.Interfaces;

namespace Appointment.Booking.Application.Appointment.Queries
{
    public class GetDoctorAvailableSlotsHandler
    {
        private readonly IDoctorAvailabilityAPI _doctorAvailabilityService;
        
        private const int ZERO_AVAILABLE_SLOTS = 0;

        public GetDoctorAvailableSlotsHandler(IDoctorAvailabilityAPI doctorAvailabilityService)
        {
            _doctorAvailabilityService = doctorAvailabilityService;
        }
        
        public async Task<DoctorAvailableSlotsResponse> Handle(DoctorAvailableSlotsRequest request)
        {
            var slots =  await _doctorAvailabilityService.GetAllUnreservedSlotsForDoctor(request.DoctorId);

            if (slots is null || slots.Count() == ZERO_AVAILABLE_SLOTS )
                throw new ArgumentNullException($"No available slots for doctor with Id: {request.DoctorId}", "Slots");

            return new DoctorAvailableSlotsResponse(slots);
        }
    }
}