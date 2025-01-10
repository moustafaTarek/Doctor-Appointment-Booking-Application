using Appointment.Booking.Application.Appointment.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Appointment.Booking.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly GetDoctorAvailableSlotsHandler _getDoctorAvailableSlotsHandler;

        public DoctorsController(GetDoctorAvailableSlotsHandler getDoctorAvailableSlotsHandler)
        {
            _getDoctorAvailableSlotsHandler = getDoctorAvailableSlotsHandler;
        }

        [HttpGet("{doctorId}/AvailableSlots")]
        public async Task<IActionResult> GetAvailableSlots(Guid doctorId)
        {
            var docAvailableSlotsGetResponse = await _getDoctorAvailableSlotsHandler.Handle(new DoctorAvailableSlotsRequest { DoctorId = doctorId});
            
            return Ok(docAvailableSlotsGetResponse);
        }
    }
}
