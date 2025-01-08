using Doctor.Availability.Core.Dtos.SlotDtos;

namespace Appointment.Booking.Application.Appointment.Queries
{
    public  class DoctorAvailableSlotsResponse
    {
        public string DoctorName { get; }
        public Guid? DoctorId { get; }
        public List<AvailableSlots> AvailableSlots { get; }

        public DoctorAvailableSlotsResponse(IList<SlotGetResponse> slots)
        {
            DoctorName = slots.FirstOrDefault()?.DoctorName;
            DoctorId = slots.FirstOrDefault()?.DoctorId == null ? Guid.Empty : slots.FirstOrDefault()?.DoctorId;

            AvailableSlots = slots.Select(e => new AvailableSlots
                             {
                                 SlotId = e.SlotId,
                                 SlotTime = e.Time,
                                 Cost = e.Cost
                             }).ToList();
        }
    }

    public class AvailableSlots
    {
        public Guid SlotId { get; set; }
        public DateTimeOffset SlotTime { get; set; }
        public Double Cost { get; set; }
    }
}
