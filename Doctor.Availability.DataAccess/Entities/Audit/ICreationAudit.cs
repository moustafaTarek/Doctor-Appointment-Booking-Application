namespace Doctor.Availability.DataAccess.Entities.Audit
{
    public interface ICreationAudit
    {
        public DateTimeOffset CreationDate { get; set; }
    }
}
