using Appointment.Booking.Domain.IRepositories;
using Appointment.Booking.Infrastructure.Db;
using Appointment.Booking.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Appointment.Booking.Infrastructure.Repositories
{
    internal class AppointmentRepo : IAppointmentRepo
    {
        private readonly AppointmentBookingDbContext _context;
        private readonly DbSet<AppointmentEntity> _appointments;

        public AppointmentRepo(AppointmentBookingDbContext context)
        {
            _context = context;
            _appointments = context.appointments;
        }

        public async Task<int> AddAppointment(Domain.Models.Appointment appointment)
        {
            _appointments.Add(new AppointmentEntity
            {
                Id = appointment.Id,
                PatientId = appointment.PatientId,
                DoctorId = appointment.DoctorId,
                SlotId = appointment.SlotId,
                ReservedAt = appointment.ReservedAt,
                StatusId = (short)appointment.Status 
            });
            
            return await _context.SaveChangesAsync();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
