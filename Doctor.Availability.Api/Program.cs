
using Doctor.Availability.Core;
using Doctor.Availability.Core.Doctor;
using Doctor.Availability.Core.Slot;
using Doctor.Availability.DataAccess.Db;
using Doctor.Availability.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Doctor.Availability.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            
            builder.Services.AddScoped<DoctorAvailabilityService>()
                            .AddScoped<DoctorService>()
                            .AddScoped<DoctorRepository>()
                            .AddScoped<SlotService>()
                            .AddScoped<SlotRepository>()
                            .AddDbContextPool<ApplicationDbContext>(options =>
                            {
                                options.UseNpgsql("host=localhost;port=5432;database=modular-monolith;user Id=postgres;password=postgres;");
                            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
