using Doctor.Appointment.Management.Core.Models;
using Doctor.Appointment.Management.Core.OutputPorts.IRepositories;
using Doctor.Appointment.Management.Shell.Db;
using AppointmentStatusEntity = Doctor.Appointment.Management.Shell.Entities.AppointmentStatus;
using Microsoft.EntityFrameworkCore;
using MediatR;
using Integration.Events;

namespace Doctor.Appointment.Management.Shell.Repositories
{
    internal class AppointmentStatusRepository : IAppointmentStatusRepository
    {
        private readonly AppointmentManagemnetDbContext _context;
        private readonly DbSet<AppointmentStatusEntity> _appointmentStatuses;
        private readonly IMediator _mediator;

        public AppointmentStatusRepository(AppointmentManagemnetDbContext context, IMediator appointmentExitsHandler, IMediator mediator)
        {
            _context = context;
            _appointmentStatuses = context.AppointmentStatuses;
            _mediator = mediator;
        }

        public async Task<Guid> Add(AppointmentStatus appointmentStatus)
        {
            if (!await _mediator.Send(new AppointmentExistsQueryEvent { Id = appointmentStatus.AppointmentId.Id }))
            {
                throw new Exception("Appointment does not exist");
            }

            AppointmentStatusEntity appointmentStatusEntity = new AppointmentStatusEntity
            {
                AppontmentId = appointmentStatus.AppointmentId.Id,
                StatusId = appointmentStatus.Status.Id,
                CreatedAt = DateTimeOffset.UtcNow
            };

            await _appointmentStatuses.AddAsync(appointmentStatusEntity);
            await _context.SaveChangesAsync();
            
            return appointmentStatusEntity.Id;
        }
    }
}
