using Doctor.Availability.Core.Doctor;
using Doctor.Availability.Core.Slot;
using Doctor.Availability.DataAccess.Db;
using Doctor.Availability.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Doctor.Availability.Core
{
    public static class DoctorAvailabilityServiceCollection
    {
        public static IServiceCollection AddDoctorAvailabilityService(this IServiceCollection services)
        {
            services.AddScoped<DoctorAvailabilityService>();
            services.AddScoped<DoctorService>();
            services.AddScoped<SlotService>();
            services.AddScoped<DoctorRepository>();
            services.AddScoped<SlotRepository>();
            services.AddDbContextPool<ApplicationDbContext>(options =>
            {
                options.UseNpgsql("host=localhost;port=5432;database=modular-monolith;user Id=postgres;password=postgres;");
            });
            return services;
        }
    }
}
