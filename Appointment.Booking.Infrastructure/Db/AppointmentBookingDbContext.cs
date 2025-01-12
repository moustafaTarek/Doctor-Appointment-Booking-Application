using Appointment.Booking.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Appointment.Booking.Infrastructure.Db
{
    public class AppointmentBookingDbContext : DbContext
    {
        public DbSet<AppointmentEntity> appointments { get; set; }
        public DbSet<PatientEntity> Patients { get; set; }

        public AppointmentBookingDbContext(DbContextOptions<AppointmentBookingDbContext> options) : base(options)
        {

        }
    }
}
