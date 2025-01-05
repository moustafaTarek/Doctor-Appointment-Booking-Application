namespace Doctor.Availability.DataAccess.Entities.Audit
{
    public interface IModificationAudit
    {
        public DateTimeOffset ModificationDate { get; set; }
    }
}
