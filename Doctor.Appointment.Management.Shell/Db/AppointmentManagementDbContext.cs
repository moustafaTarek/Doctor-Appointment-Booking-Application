using Doctor.Appointment.Management.Shell.Entities;
using Microsoft.EntityFrameworkCore;

namespace Doctor.Appointment.Management.Shell.Db
{
    public class AppointmentManagementDbContext : DbContext
    {
        public DbSet<Status> Statuses { get; set; }
        public DbSet<AppointmentStatus> AppointmentStatuses { get; set; }
        
        public AppointmentManagementDbContext(DbContextOptions<AppointmentManagementDbContext> options) : base(options)
        {
        }
    }
}
