using Doctor.Appointment.Management.Core.OutputPorts.IRepositories;
using Doctor.Appointment.Management.Shell.Db;
using Doctor.Appointment.Management.Shell.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Doctor.Appointment.Management.Core;

namespace Doctor.Appointment.Management.Shell
{
    public static class DoctorAppointmentServiceCollection
    {
        public static IServiceCollection AddDoctorAppointmentServiceCollection(this IServiceCollection services)
        {
            return
                services.AddScoped<IAppointmentStatusRepository, AppointmentStatusRepository>()
                        .AddScoped<IStatusRepository, StatusRepository>()     
                        .AddDbContext<AppointmentManagementDbContext>(options =>
                        {
                            options.UseNpgsql("host=localhost;port=5432;database=modular-monolith-AppDoctorManagment;user Id=postgres;password=postgres;");
                        })
                        .AddDoctorAppointmentServiceCoreCollection();
        }
    }
}
