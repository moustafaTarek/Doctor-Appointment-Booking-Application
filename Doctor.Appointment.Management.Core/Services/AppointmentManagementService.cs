using Doctor.Appointment.Management.Core.Models;
using Doctor.Appointment.Management.Core.OutputPorts.IRepositories;
using Integration.Interfaces;

namespace Doctor.Appointment.Management.Core.Services
{
    internal class AppointmentManagementService : IAppointmentManagmentAPI
    {
        private readonly IAppointmentStatusRepository _appointmentStatusRepository;

        public AppointmentManagementService(IAppointmentStatusRepository appointmentStatusRepository)
        {
            _appointmentStatusRepository = appointmentStatusRepository;
        }

        public async Task<string> MarkAppointment(Guid appointmentId, short appointmentStatusId)
        {
            AppointmentStatus appointmentStatus = AppointmentStatus.Create(appointmentId, appointmentStatusId);
            
            var appontmentStatusRecordId = await _appointmentStatusRepository.Add(appointmentStatus);
            
            return $"A new appointment status has been added with Id: {appontmentStatusRecordId}";
        }
    }
}
