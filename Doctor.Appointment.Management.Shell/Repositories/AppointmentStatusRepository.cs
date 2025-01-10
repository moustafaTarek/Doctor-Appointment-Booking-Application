using Doctor.Appointment.Management.Core.Models;
using Doctor.Appointment.Management.Core.OutputPorts.IRepositories;
using Doctor.Appointment.Management.Shell.Db;
using AppointmentStatusEntity = Doctor.Appointment.Management.Shell.Entities.AppointmentStatus;
using Microsoft.EntityFrameworkCore;

namespace Doctor.Appointment.Management.Shell.Repositories
{
    internal class AppointmentStatusRepository : IAppointmentStatusRepository
    {
        private readonly AppointmentManagemnetDbContext _context;
        private readonly DbSet<AppointmentStatusEntity> _appointmentStatuses;

        public AppointmentStatusRepository(AppointmentManagemnetDbContext context)
        {
            _context = context;
            _appointmentStatuses = context.AppointmentStatuses;
        }

        public async Task<Guid> Add(AppointmentStatus appointmentStatus)
        {
            AppointmentStatusEntity appointmentStatusEntity = new AppointmentStatusEntity
            {
                AppontmentId = appointmentStatus.AppointmentId.Id,
                StatusId = appointmentStatus.Status.Id,
                CreatedAt = DateTimeOffset.Now
            };

            await _appointmentStatuses.AddAsync(appointmentStatusEntity);
            await _context.SaveChangesAsync();
            
            return appointmentStatusEntity.Id;
        }
    }
}
