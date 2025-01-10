using Doctor.Availability.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using DoctorEntity = Doctor.Availability.DataAccess.Entities.Doctor;

namespace Doctor.Availability.DataAccess.Db
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<DoctorEntity> Doctors { get; set; }
        public DbSet<Slot> Slots { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
    }
}