using Doctor.Availability.Core.Dtos.SlotDtos;
using Doctor.Availability.DataAccess.Repositories;
using SlotEntity = Doctor.Availability.DataAccess.Entities.Slot;

namespace Doctor.Availability.Core.Slot
{
    public class SlotService
    {
        private readonly SlotRepository _slotRepository;

        public SlotService(SlotRepository slotRepository)
        {
            _slotRepository = slotRepository;
        }

        public async Task<IList<SlotEntity>> GetAllSlotsForDoctorId(Guid doctorId)
        {
            return await _slotRepository.GetAll(f => f.DoctorId == doctorId);
        }

        public async Task<IList<SlotEntity>> GetAllSlotsForDoctorId(Guid doctorId, short slotStatusId)
        {
            return await _slotRepository.GetAll(f => f.DoctorId == doctorId && f.StatusId == slotStatusId);
        }

        public async Task<SlotEntity> GetIfExists(Guid slotId)
        {
           return await _slotRepository.GetById(slotId) ?? throw new ArgumentNullException($"No slots found with Id: {slotId}");
        }

        public async Task CheckIfSlotAlreadyExistsForDoctor(Guid doctorId, DateTimeOffset dateTimeOffset)
        {
            var isExists = await _slotRepository.IsExists(e => e.DoctorId == doctorId && e.Time.Day == dateTimeOffset.Day && e.Time.Hour == dateTimeOffset.Hour);

            if (isExists)
                throw new ArgumentNullException($"Already slot exists in the same hour");
        }

        public async Task AddNewSlotForDoctor(Guid doctorId, SlotAddRequest slotAddRequest)
        {
            SlotEntity newSlot = new SlotEntity
            {
                DoctorId = doctorId,
                CreationDate = DateTimeOffset.UtcNow,
                StatusId = 1,
                Cost = slotAddRequest.Cost,
                IsReserved = false,
                Time = slotAddRequest.Time
            };

            await _slotRepository.Add(newSlot);
            await _slotRepository.SaveChangesAsync();
        }
    }
}
