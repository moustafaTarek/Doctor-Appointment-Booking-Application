using Doctor.Availability.Core.Doctor;
using Doctor.Availability.Core.Doctor.DoctorDtos;
using Doctor.Availability.Core.Dtos.SlotDtos;
using Doctor.Availability.Core.Slot;

namespace Doctor.Availability.Core
{
    public class DoctorAvailabilityService
    {
        private readonly DoctorService _doctorService;
        private readonly SlotService _slotService;

        public DoctorAvailabilityService(SlotService slotService, DoctorService doctorService)
        {
            _slotService = slotService;
            _doctorService = doctorService;
        }

        public async Task<IList<SlotGetResponse>> GetAllSlotsForDoctor(Guid doctorId)
        {
            await _doctorService.CheckIfNotExists(doctorId);

            var slots = await _slotService.GetAllSlotsForDoctorId(doctorId);

            return SlotGetResponse.Of(slots);
        }

        public async Task<IList<SlotGetResponse>> GetAllSlotsForDoctor(Guid doctorId, short statusId)
        {
            await _doctorService.CheckIfNotExists(doctorId);

            var slots = await _slotService.GetAllSlotsForDoctorId(doctorId, statusId);

            return SlotGetResponse.Of(slots);
        }

        public async Task AddSlotForDoctor(Guid doctorId, SlotAddRequest slotAddRequest)
        {
            await _doctorService.CheckIfNotExists(doctorId);

            await _slotService.AddNewSlotForDoctor(doctorId, slotAddRequest);
        }

        public async Task<SlotGetResponse> GetSlot(Guid slotId)
        {
            var slot = await _slotService.GetIfExists(slotId);

            return SlotGetResponse.Of(slot);
        }

        public async Task<DoctorGetResponse> GetDoctor(Guid doctorId)
        {
            var doctor = await _doctorService.GetIfExists(doctorId);

            return DoctorGetResponse.Of(doctor);
        }
    }
}