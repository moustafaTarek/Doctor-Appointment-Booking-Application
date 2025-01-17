using Doctor.Appointment.Management.Core.Services;
using Integration.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Doctor.Appointment.Management.Core
{
    public static class DoctorAppointmentCoreServiceCollection
    {
        public static IServiceCollection AddDoctorAppointmentServiceCoreCollection(this IServiceCollection services)
        {
            return
                services.AddScoped<IAppointmentManagmentAPI, AppointmentManagementService>();
        }
    }
}
