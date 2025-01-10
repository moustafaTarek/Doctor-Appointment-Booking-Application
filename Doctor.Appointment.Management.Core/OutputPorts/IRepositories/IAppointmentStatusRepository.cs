using Doctor.Appointment.Management.Core.Models;

namespace Doctor.Appointment.Management.Core.OutputPorts.IRepositories
{
    public interface IAppointmentStatusRepository
    {
        Task<Guid> Add(AppointmentStatus appointmentStatus);
    }
}
