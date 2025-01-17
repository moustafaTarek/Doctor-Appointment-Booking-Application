using Appointment.Booking.Application.Appointment.Commands;
using Integration.Events;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Doctor.Appointment.System.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AppointmentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> AddAppointment([FromBody] AppointmentReservationCommandEvent appointmentReservationRequest)
        {
            string message = await _mediator.Send(appointmentReservationRequest);

            return Ok(message);
        }
    }
}