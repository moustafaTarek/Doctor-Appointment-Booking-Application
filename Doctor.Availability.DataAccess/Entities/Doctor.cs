using Doctor.Availability.DataAccess.Entities.BaseEntity;

namespace Doctor.Availability.DataAccess.Entities
{
    public class Doctor : Base<Guid>
    {
        public string Name { get; set; }
    }
}
