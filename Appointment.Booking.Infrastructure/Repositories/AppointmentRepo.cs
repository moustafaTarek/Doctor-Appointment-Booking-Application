using Appointment.Booking.Domain.Enums;
using Appointment.Booking.Domain.IRepositories;
using Appointment.Booking.Infrastructure.Db;
using Appointment.Booking.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Appointment.Booking.Infrastructure.Repositories
{
    public class AppointmentRepo : IAppointmentRepo
    {
        private readonly AppointmentBookingDbContext _context;
        private readonly DbSet<AppointmentEntity> _appointments;

        public AppointmentRepo(AppointmentBookingDbContext context)
        {
            _context = context;
            _appointments = context.appointments;
        }

        public async Task<Guid> AddAppointment(Domain.Models.Appointment appointment)
        {
            var newApp = new AppointmentEntity
            {
                Id = appointment.Id,
                PatientId = appointment.PatientId,
                DoctorId = appointment.DoctorId,
                SlotId = appointment.SlotId,
                ReservedAt = appointment.ReservedAt,
                StatusId = (short)appointment.Status
            };
            
            _appointments.Add(newApp);
            
            await _context.SaveChangesAsync();

            return newApp.Id;
        }

        public async Task<bool> AppointmentExists(Guid appointmentId)
        {
            return await _appointments.AnyAsync(a => a.Id == appointmentId);
        }

        public async Task<IEnumerable<Domain.Models.Appointment>> GetNextAppointmentsForDoctor(Guid doctorId)
        {
            IList<AppointmentEntity> x = await _appointments.Where(a => a.DoctorId == doctorId && a.StatusId == (short)AppointmentStatus.Pending)
                                               .OrderBy(a => a.ReservedAt)
                                               .ToListAsync();

            return x.Select(a => Domain.Models.Appointment.Create(a.Id, a.DoctorId, a.PatientId, a.SlotId, a.ReservedAt, (AppointmentStatus)a.StatusId));
        }
    }
}