using Doctor.Availability.DataAccess.Db;
using Doctor.Availability.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Doctor.Availability.DataAccess.Repositories
{
    public class SlotRepository
    {
        private readonly DbSet<Slot> _slots;
        private readonly ApplicationDbContext _applicationDbContext;

        public SlotRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
            _slots = applicationDbContext.Slots;
        }

        public async Task<Slot?> GetById(Guid slotId)
        {
            return await _slots.FindAsync(slotId);
        }

        public async Task<IList<Slot>> GetAll(Expression<Func<Slot,bool>> expression)
        {
            return await _slots
                         .Where(expression)
                         .ToListAsync();
        }

        public async Task<bool> IsExists(Expression<Func<Slot,bool>> expression)
        {
            return await _slots.AnyAsync(expression);
        }

        public async Task Add(Slot slot)
        {
            await _slots.AddAsync(slot);
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
