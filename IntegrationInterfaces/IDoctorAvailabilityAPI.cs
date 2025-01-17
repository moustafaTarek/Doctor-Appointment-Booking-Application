using Integration.DTOs;

namespace Integration.Interfaces
{
    public interface IDoctorAvailabilityAPI
    {
        Task<IList<SlotGetResponse>> GetAllSlotsForDoctor(Guid doctorId);
        Task<IList<SlotGetResponse>> GetAllUnreservedSlotsForDoctor(Guid doctorId);
        Task AddSlotForDoctor(Guid doctorId, SlotAddRequest slotAddRequest);
        Task<SlotGetResponse> GetSlot(Guid slotId);
        Task<DoctorGetResponse> GetDoctor(Guid doctorId);
        Task<Guid> AddDoctor(DoctorAddRequest doctorAddRequest);
        Task UpdateSlotAsReserved(Guid slotId);
    }
}
