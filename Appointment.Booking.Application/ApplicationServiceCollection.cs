
using Appointment.Booking.Application.Appointment.Commands;
using Appointment.Booking.Application.Appointment.Queries;
using Appointment.Booking.Application.Appointment.Queries.CheckIfAppointmentExistsUseCase;
using Appointment.Booking.Application.Appointment.Queries.GetNextAppointmentsForDoctorUseCase;
using Microsoft.Extensions.DependencyInjection;

namespace Appointment.Booking.Application
{
    public static class ApplicationServiceCollection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<ReserveAppointmentHandler>();
            services.AddScoped<GetDoctorAvailableSlotsHandler>();
            services.AddScoped<GetNextAppointmentsHandler>();
            services.AddScoped<AppointmentExitsHandler>();

            return services;
        }
    }
}
