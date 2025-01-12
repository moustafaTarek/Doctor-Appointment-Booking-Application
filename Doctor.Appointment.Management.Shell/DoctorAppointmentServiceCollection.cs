using Appointment.Booking.Application.Appointment.Queries.CheckIfAppointmentExistsUseCase;
using Appointment.Booking.Domain.IRepositories;
using Appointment.Booking.Infrastructure.Db;
using Appointment.Booking.Infrastructure.Repositories;
using Doctor.Appointment.Management.Core.OutputPorts.IRepositories;
using Doctor.Appointment.Management.Core.Services;
using Doctor.Appointment.Management.Shell.Db;
using Doctor.Appointment.Management.Shell.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Doctor.Appointment.Management.Shell
{
    public static class DoctorAppointmentServiceCollection
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services)
        {
            return 
                services.AddScoped<IAppointmentStatusRepository, AppointmentStatusRepository>()
                        .AddScoped<IStatusRepository,StatusRepository>()
                        .AddScoped<AppointmentManagmentService>()
                        .AddScoped<AppointmentExitsHandler>()
                        .AddScoped<IAppointmentRepo, AppointmentRepo>()
                        .AddDbContext<AppointmentManagemnetDbContext>(options =>
                        {
                            options.UseNpgsql("host=localhost;port=5432;database=modular-monolith-AppDoctorManagment;user Id=postgres;password=postgres;");
                        })
                        .AddDbContext<AppointmentBookingDbContext>(options =>
                        {
                            options.UseNpgsql("host=localhost;port=5432;database=modular-monolith-AppBooking;user Id=postgres;password=postgres;");
                        });
        }
    }
}
