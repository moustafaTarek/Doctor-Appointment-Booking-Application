using Doctor.Availability.Core.Doctor;
using Doctor.Availability.Core.Slot;
using Integration.DTOs;
using Integration.Interfaces;

namespace Doctor.Availability.Core
{
    internal class DoctorAvailabilityService : IDoctorAvailabilityAPI
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

            return slots.Select(e => new SlotGetResponse
            {
                SlotId = e.Id,
                Cost = e.Cost,
                Time = e.Time,
                DoctorId = e.DoctorId,
                DoctorName = e.Doctor.Name,
                IsReserved = e.IsReserved
                
            }).ToList();
        }

        public async Task<IList<SlotGetResponse>> GetAllUnreservedSlotsForDoctor(Guid doctorId)
        {
            await _doctorService.CheckIfNotExists(doctorId);

            var slots = await _slotService.GetAllUnReservedSlotsForDoctorId(doctorId);

            return slots.Select(e => new SlotGetResponse
            {
                SlotId = e.Id,
                Cost = e.Cost,
                Time = e.Time,
                DoctorId = e.DoctorId,
                DoctorName = e.Doctor.Name,
                IsReserved = e.IsReserved

            }).ToList();
        }

        public async Task AddSlotForDoctor(Guid doctorId, SlotAddRequest slotAddRequest)
        {
            await _doctorService.CheckIfNotExists(doctorId);

            await _slotService.AddNewSlotForDoctor(doctorId, slotAddRequest);
        }

        public async Task<SlotGetResponse> GetSlot(Guid slotId)
        {
            var slot = await _slotService.GetIfExists(slotId);

            return new SlotGetResponse
            {
                SlotId = slot.Id,
                Cost = slot.Cost,
                Time = slot.Time,
                DoctorId = slot.DoctorId,
                DoctorName = slot.Doctor.Name,
                IsReserved = slot.IsReserved

            };
        }

        public async Task<DoctorGetResponse> GetDoctor(Guid doctorId)
        {
            var doctor = await _doctorService.GetIfExists(doctorId);

            return new DoctorGetResponse
            {
                Id = doctor.Id,
                Name = doctor.Name
            };
        }

        public async Task<Guid> AddDoctor(DoctorAddRequest doctorAddRequest)
        {
            var doctorId = await _doctorService.AddDoctor(doctorAddRequest.Name);

            return doctorId;
        }

        public async Task UpdateSlotAsReserved(Guid slotId)
        {
            var slot = await _slotService.GetIfExists(slotId);

            await _slotService.UpdateSlot(slot);
        }
    }
}