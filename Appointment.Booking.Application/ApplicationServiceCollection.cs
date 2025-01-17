
using Appointment.Booking.Application.Appointment.Commands;
using Appointment.Booking.Application.Appointment.Queries.CheckIfAppointmentExistsUseCase;
using Appointment.Booking.Application.Appointment.Queries.GetDoctorAvailableSlotsUseCase;
using Appointment.Booking.Application.Appointment.Queries.GetNextAppointmentsForDoctorUseCase;
using Microsoft.Extensions.DependencyInjection;

namespace Appointment.Booking.Application
{
    public static class ApplicationServiceCollection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<GetDoctorAvailableSlotsHandler>();
            services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssembly(typeof(AppointmentExitsHandler).Assembly);
                config.RegisterServicesFromAssembly(typeof(GetNextAppointmentsHandler).Assembly);
                config.RegisterServicesFromAssembly(typeof(ReserveAppointmentHandler).Assembly);
            });

            return services;
        }
    }
}
