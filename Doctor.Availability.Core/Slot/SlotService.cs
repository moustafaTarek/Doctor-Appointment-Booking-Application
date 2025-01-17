using Doctor.Availability.DataAccess.Repositories;
using Integration.DTOs;
using System.Globalization;
using SlotEntity = Doctor.Availability.DataAccess.Entities.Slot;

namespace Doctor.Availability.Core.Slot
{
    internal class SlotService
    {
        private readonly SlotRepository _slotRepository;
        private const string DATE_FORMAT = "dd/MM/yyyy hh:mm tt";

        public SlotService(SlotRepository slotRepository)
        {
            _slotRepository = slotRepository;
        }

        public async Task<IList<SlotEntity>> GetAllSlotsForDoctorId(Guid doctorId)
        {
            return await _slotRepository.GetAll(f => f.DoctorId == doctorId);
        }

        public async Task<IList<SlotEntity>> GetAllUnReservedSlotsForDoctorId(Guid doctorId)
        {
            return await _slotRepository.GetAll(f => f.DoctorId == doctorId && !f.IsReserved);
        }

        public async Task<SlotEntity> GetIfExists(Guid slotId)
        {
           return await _slotRepository.GetById(slotId) ?? throw new ArgumentNullException($"No slots found with Id: {slotId}");
        }

        public async Task AddNewSlotForDoctor(Guid doctorId, SlotAddRequest slotAddRequest)
        {
            try
            {
                if (DateTimeOffset.TryParseExact(slotAddRequest.Time, DATE_FORMAT, CultureInfo.InvariantCulture, DateTimeStyles.None, out var dateTimeOffset))
                {

                    SlotEntity newSlot = new SlotEntity
                    {
                        DoctorId = doctorId,
                        CreationDate = DateTimeOffset.UtcNow,
                        Cost = slotAddRequest.Cost,
                        IsReserved = false,
                        Time = dateTimeOffset.UtcDateTime
                    };

                    await _slotRepository.Add(newSlot);
                    await _slotRepository.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                throw new ArgumentNullException($"Error while adding slot for doctor: {e.Message}");
            }
        }

        public async Task UpdateSlot(SlotEntity slot)
        {
            slot.IsReserved = true;

            await _slotRepository.SaveChangesAsync();
        }
    }
}