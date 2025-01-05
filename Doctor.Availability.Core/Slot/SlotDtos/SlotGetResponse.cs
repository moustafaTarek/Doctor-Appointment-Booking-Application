using System.Collections.Generic;
using SlotEntity = Doctor.Availability.DataAccess.Entities.Slot;

namespace Doctor.Availability.Core.Dtos.SlotDtos
{
    public class SlotGetResponse
    {
        public Guid SlotId { get; set; }
        public DateTimeOffset Time { get; set; }
        public Guid DoctorId { get; set; }
        public string DoctorName { get; set; }
        public bool IsReserved { get; set; }
        public double Cost { get; set; }

        private SlotGetResponse(SlotEntity slotEntity)
        {
            SlotId = slotEntity.Id;
            Time = slotEntity.Time;
            DoctorId = slotEntity.DoctorId;
            DoctorName = slotEntity.Doctor.Name;
            IsReserved = slotEntity.IsReserved;
            Cost = slotEntity.Cost;
        }

        public static SlotGetResponse Of(SlotEntity slotEntity)
        {
            return new SlotGetResponse(slotEntity);
        }

        public static IList<SlotGetResponse> Of(IList<SlotEntity> slotEntities)
        {
            return slotEntities
                  .Select(e => new SlotGetResponse(e))
                  .ToList();
        }
    }
}
