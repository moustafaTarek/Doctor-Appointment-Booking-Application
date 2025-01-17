using Appointment.Booking.Application.Appointment.Queries.GetNextAppointmentsForDoctorUseCase;
using Doctor.Appointment.Management.Core.Services;
using Integration.Events;
using Integration.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Doctor.Appointment.System.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorManagementsController : ControllerBase
    {
        private readonly IAppointmentManagmentAPI _appointmentManagmentService;
        private readonly IMediator _mediator;
        public DoctorManagementsController(IAppointmentManagmentAPI appointmentManagmentService, IMediator mediator)
        {
            _appointmentManagmentService = appointmentManagmentService;
            _mediator = mediator;
        }

        [HttpGet("{doctorId}/upcomingAppointments")]
        public async Task<IActionResult> GetAppointments(Guid doctorId)
        {
            var appointments = await _mediator.Send(new AppointmentsGetQueryEvent { DoctorId = doctorId});

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
