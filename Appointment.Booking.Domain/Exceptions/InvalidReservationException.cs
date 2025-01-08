
namespace Appointment.Booking.Domain.Exceptions
{
    public class InvalidReservationException : Exception
    {
        public InvalidReservationException(string message) : base(message){ }
    }
}
