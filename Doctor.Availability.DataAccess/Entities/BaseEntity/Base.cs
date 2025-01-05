namespace Doctor.Availability.DataAccess.Entities.BaseEntity
{
    public abstract class Base<IType>
    {
        public IType Id { get; set; }
    }
}
