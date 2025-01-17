using Microsoft.AspNetCore.Mvc;
using Integration.Interfaces;
using Integration.DTOs;
using Appointment.Booking.Application.Appointment.Queries.GetDoctorAvailableSlotsUseCase;
using MediatR;
using Integration.Events;

namespace Doctor.Appointment.System.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly IDoctorAvailabilityAPI _doctorAvailabilityService;
        private readonly IMediator _mediator;

        public DoctorsController(IDoctorAvailabilityAPI doctorAvailabilityService, IMediator mediator)
        {
            _doctorAvailabilityService = doctorAvailabilityService;
            _mediator = mediator;
        }

        [HttpGet("{doctorId}/AvailableSlots")]
        public async Task<IActionResult> GetAvailableSlots(Guid doctorId)
        {
            var docAvailableSlotsGetResponse = await _mediator.Send(new DoctorAvailableSlotsQueryEvent { DoctorId = doctorId });

            return Ok(docAvailableSlotsGetResponse);
        }

        [HttpPost("{doctorId}/slot")]
        public async Task<IActionResult> AddSlotForDoctor([FromRoute] Guid doctorId, [FromBody] SlotAddRequest slotAddRequest)
        {
            await _doctorAvailabilityService.AddSlotForDoctor(doctorId, slotAddRequest);

            return Ok("Slot added correctly to doctor");
        }

        [HttpGet("{doctorId}/slots")]
        public async Task<IActionResult> GetAllSlotsForDoctor([FromRoute] Guid doctorId)
        {
            var slots = await _doctorAvailabilityService.GetAllSlotsForDoctor(doctorId);

            return Ok(slots);
        }

        [HttpPost]
        public async Task<IActionResult> AddDoctor([FromBody] DoctorAddRequest doctorAddRequest)
        {
            var doctorId = await _doctorAvailabilityService.AddDoctor(doctorAddRequest);

            return Ok(doctorId);
        }
    }
}