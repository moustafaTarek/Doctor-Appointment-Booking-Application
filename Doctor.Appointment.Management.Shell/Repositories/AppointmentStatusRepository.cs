using Doctor.Appointment.Management.Core.Models;
using Doctor.Appointment.Management.Core.OutputPorts.IRepositories;
using Doctor.Appointment.Management.Shell.Db;
using AppointmentStatusEntity = Doctor.Appointment.Management.Shell.Entities.AppointmentStatus;
using Microsoft.EntityFrameworkCore;
using Appointment.Booking.Application.Appointment.Queries.CheckIfAppointmentExistsUseCase;

namespace Doctor.Appointment.Management.Shell.Repositories
{
    internal class AppointmentStatusRepository : IAppointmentStatusRepository
    {
        private readonly AppointmentManagemnetDbContext _context;
        private readonly DbSet<AppointmentStatusEntity> _appointmentStatuses;
        private readonly AppointmentExitsHandler _appointmentExitsHandler;

        public AppointmentStatusRepository(AppointmentManagemnetDbContext context, AppointmentExitsHandler appointmentExitsHandler)
        {
            _context = context;
            _appointmentStatuses = context.AppointmentStatuses;
            _appointmentExitsHandler = appointmentExitsHandler;
        }

        public async Task<Guid> Add(AppointmentStatus appointmentStatus)
        {
            if (!await _appointmentExitsHandler.Handle(appointmentStatus.AppointmentId.Id))
            {
                throw new Exception("Appointment does not exist");
            }

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
