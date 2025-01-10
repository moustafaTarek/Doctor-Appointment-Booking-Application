using Doctor.Appointment.Management.Core.Enums;

namespace Doctor.Appointment.Management.Core.Models
{
    public class Status
    {
        public short Id { get; set; }
        public string Value { get; set; }

        public Status(short value)
        {
            Id = value switch
            {
                (short)StatusEnum.Completed => 0,
                (short)StatusEnum.Cancel => 1,
                (short)StatusEnum.Pending => 2,
                _ => throw new ArgumentException("Invalid status value")
            };

            Value = value switch
            {
                (short)StatusEnum.Completed => StatusEnum.Completed.ToString(),
                (short)StatusEnum.Cancel => StatusEnum.Completed.ToString(),
                (short)StatusEnum.Pending => StatusEnum.Completed.ToString(),
                _ => throw new ArgumentException("Invalid status value")
            };
        }
    }
}