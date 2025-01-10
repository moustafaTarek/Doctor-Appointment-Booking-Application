using Doctor.Availability.DataAccess.Entities.Audit;
using Doctor.Availability.DataAccess.Entities.BaseEntity;

namespace Doctor.Availability.DataAccess.Entities
{
    public class Slot : Base<Guid>, ICreationAudit
    {
        public Guid DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        public short StatusId { get; set; }
        public bool IsReserved { get; set; }
        public double Cost { get; set; }
        public DateTimeOffset Time { get; set; }
        public DateTimeOffset CreationDate { get; set; }
        public DateTimeOffset? ReservedAt { get; set; }
    }
}