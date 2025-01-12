
using Doctor.Appointment.Management.Core.Models;
using Doctor.Appointment.Management.Core.OutputPorts.IRepositories;

namespace Doctor.Appointment.Management.Core.Services
{
    public class AppointmentManagmentService
    {
        private readonly IAppointmentStatusRepository _appointmentStatusRepository;

        public AppointmentManagmentService(IAppointmentStatusRepository appointmentStatusRepository)
        {
            _appointmentStatusRepository = appointmentStatusRepository;
        }

        public async Task<string> MarkAppointment(Guid appoitmentId, short appointmentStatusId)
        {
            AppointmentStatus appointmentStatus = AppointmentStatus.Create(appoitmentId, appointmentStatusId);
            
            var appontmentStatusRecordId = await _appointmentStatusRepository.Add(appointmentStatus);
            
            return $"A new appointment status has been added with Id: {appontmentStatusRecordId}";
        }
    }
}
