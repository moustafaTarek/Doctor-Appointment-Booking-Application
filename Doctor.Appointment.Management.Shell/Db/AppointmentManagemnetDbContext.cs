
using Doctor.Appointment.Management.Shell.Entities;
using Microsoft.EntityFrameworkCore;

namespace Doctor.Appointment.Management.Shell.Db
{
    public class AppointmentManagemnetDbContext : DbContext
    {
        public DbSet<Status> Statuses { get; set; }
        public DbSet<AppointmentStatus> AppointmentStatuses { get; set; }
        
        public AppointmentManagemnetDbContext(DbContextOptions<AppointmentManagemnetDbContext> options) : base(options)
        {
        }
    }
}
