namespace Appointment.Booking.Domain.Models
{
    public class Patient
    {
        public Guid Id { get; }
        public string Name { get; }

        private Patient(string name)
        {
            Name = name;
        }

        public static Patient Create(string name)
        {
            return new Patient(name);
        }
    }
}
