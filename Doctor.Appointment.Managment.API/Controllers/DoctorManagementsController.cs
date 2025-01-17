using Appointment.Booking.Application.Appointment.Queries.GetNextAppointmentsForDoctorUseCase;
using Doctor.Appointment.Management.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Doctor.Appointment.Managment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorManagementsController : ControllerBase
    {
        private readonly AppointmentManagmentService _appointmentManagmentService;
        private readonly GetNextAppointmentsHandler _getNextAppointmentsHandler;
        public DoctorManagementsController(AppointmentManagmentService appointmentManagmentService, GetNextAppointmentsHandler getNextAppointmentsHandler)
        {
            _appointmentManagmentService = appointmentManagmentService;
            _getNextAppointmentsHandler = getNextAppointmentsHandler;
        }

        [HttpGet("{doctorId}/upcomingAppointments")]
        public async Task<IActionResult> GetAppointments(Guid doctorId)
        {
            var appointments = await _getNextAppointmentsHandler.Handle(doctorId);

            return Ok(appointments);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAppointment([FromBody] AppointmentStatusAddRequest request)
        {
            var message = await _appointmentManagmentService.MarkAppointment(request.AppointmentId, request.StatusId);
            
            return Ok(message);
        }

        public class AppointmentStatusAddRequest
        {
            public Guid AppointmentId { get; set; }
            public short StatusId { get; set; }
        }   
    }
}
