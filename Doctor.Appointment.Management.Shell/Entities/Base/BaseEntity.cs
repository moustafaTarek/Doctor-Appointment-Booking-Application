
namespace Doctor.Appointment.Management.Shell.Entities.Base
{
    public abstract class BaseEntity<TId>
    {
        public TId Id { get; set; }
    }
}
