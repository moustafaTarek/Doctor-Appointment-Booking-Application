using Appointment.Booking.Application.Appointment.Commands;
using Microsoft.AspNetCore.Mvc;

namespace Appointment.Booking.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly ReserveAppointmentHandler _reserveAppointmentHandler;

        public AppointmentsController(ReserveAppointmentHandler reserveAppointmentHandler)
        {
            _reserveAppointmentHandler = reserveAppointmentHandler;
        }

        [HttpPost]
        public async Task<IActionResult> AddAppointment([FromBody] AppointmentReservationRequest appointmentReservationRequest)
        {
            string message = await _reserveAppointmentHandler.Handle(appointmentReservationRequest);
            
            return Ok(message);
        }
    }
}
