using Appointment.Booking.Application;
using Appointment.Booking.Domain.IRepositories;
using Appointment.Booking.Infrastructure.Db;
using Appointment.Booking.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Appointment.Booking.Infrastructure
{
    public static class InfrastructureServiceCollection
    {
        public static IServiceCollection AddAppointmentBookingInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IAppointmentRepo, AppointmentRepo>();
            services.AddScoped<IPatientRepo, PatientRepo>();
            services.AddDbContext<AppointmentBookingDbContext>(options =>
            {
                options.UseNpgsql("host=localhost;port=5432;database=modular-monolith-AppBooking;user Id=postgres;password=postgres;");
            })
            .AddApplicationServices();
            return services;
        }
    }
}
