namespace Doctor.Appointment.Management.Shell.Entities
{
    public abstract class LookUpEntity<TId>
    {
        public TId Id { get; set; }
        public string Value { get; set; }
    }
}
