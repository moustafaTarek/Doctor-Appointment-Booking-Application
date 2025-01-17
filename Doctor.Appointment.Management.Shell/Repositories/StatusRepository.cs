using Doctor.Appointment.Management.Core.OutputPorts.IRepositories;
using Doctor.Appointment.Management.Shell.Db;
using Doctor.Appointment.Management.Shell.Entities;
using Microsoft.EntityFrameworkCore;
using Status = Doctor.Appointment.Management.Core.Models.Status;
using StatusDbEntity = Doctor.Appointment.Management.Shell.Entities.Status;

namespace Doctor.Appointment.Management.Shell.Repositories
{
    internal class StatusRepository : IStatusRepository
    {        
        private readonly DbSet<StatusDbEntity> _statuses;

        public StatusRepository(AppointmentManagementDbContext appointmentManagemnetDbContext)
        {
            _statuses = appointmentManagemnetDbContext.Statuses;
        }

        public async Task<Status?> GetStatusByIdAsync(short statusId)
        {
            var isExists = await _statuses.AnyAsync(f=>f.Id == statusId);

            if (!isExists)
                throw new Exception("Status not found");

            return new Status(statusId);
        }

        public async Task<IList<Status>> GetAllAsync()
        {
            var statuses =  await _statuses.ToListAsync();

            return statuses.Select(f => new Status(f.Id)).ToList();
        }
    }
}
