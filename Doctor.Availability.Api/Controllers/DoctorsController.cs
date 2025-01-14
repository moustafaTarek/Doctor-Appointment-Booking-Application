using Doctor.Availability.Core;
using Doctor.Availability.Core.Doctor.DoctorDtos;
using Doctor.Availability.Core.Dtos.SlotDtos;
using Microsoft.AspNetCore.Mvc;

namespace Doctor.Availability.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly DoctorAvailabilityService _doctorAvailabilityService;

        public DoctorsController(DoctorAvailabilityService doctorAvailabilityService)
        {
            _doctorAvailabilityService = doctorAvailabilityService;
        }

        [HttpPost("{doctorId}/slot")]
        public async Task<IActionResult> AddSlotForDoctor([FromRoute]Guid doctorId, [FromBody] SlotAddRequest slotAddRequest)
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
