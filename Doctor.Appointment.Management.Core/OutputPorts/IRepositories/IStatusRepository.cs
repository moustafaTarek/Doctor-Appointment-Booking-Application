using Doctor.Appointment.Management.Core.Models;

namespace Doctor.Appointment.Management.Core.OutputPorts.IRepositories
{
    public interface IStatusRepository
    {
        Task<Status?> GetStatusByIdAsync(short statusId);
        Task<IList<Status>> GetAllAsync();        
    }
}