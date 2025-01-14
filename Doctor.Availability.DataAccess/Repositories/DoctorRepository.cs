using Doctor.Availability.DataAccess.Db;
using DoctorEntity = Doctor.Availability.DataAccess.Entities.Doctor;
using Microsoft.EntityFrameworkCore;

namespace Doctor.Availability.DataAccess.Repositories
{
    public class DoctorRepository
    {
        private readonly DbSet<DoctorEntity> _doctors;
        private readonly ApplicationDbContext _applicationDbContext;

        public DoctorRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
            _doctors = applicationDbContext.Doctors;
        }

        public async Task<bool> CheckIfExists(Guid doctorId)
        {
            return await _doctors.AnyAsync(e => e.Id == doctorId);
        }

        public async Task<DoctorEntity?> GetById(Guid doctorId)
        {
            return await _doctors.FindAsync(doctorId);
        }

        public async Task AddAsync(DoctorEntity doctor)
        {
            await _doctors.AddAsync(doctor);
        }

        public int SaveChanges()
        {
            return _applicationDbContext.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _applicationDbContext.SaveChangesAsync();
        }
    }
}
