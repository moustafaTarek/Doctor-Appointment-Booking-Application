using Appointment.Confirmation.Core.Handlers;
using Microsoft.Extensions.DependencyInjection;

namespace Appointment.Confirmation.Core
{
    public static class ServiceCollectionsExtensions
    {
        public static IServiceCollection AddAppointmentConfirmationCore(this IServiceCollection services)
        {
            services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssembly(typeof(NotificationServiceHandler).Assembly);
            });

            return services;
        }
    }
}
