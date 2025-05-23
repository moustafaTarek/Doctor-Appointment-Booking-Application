using Doctor.Availability.Core;
using Doctor.Appointment.Management.Shell;
using Appointment.Booking.Infrastructure;
using Appointment.Confirmation.Core;
namespace Doctor.Appointment.System.API
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

            builder.Services.AddDoctorAvailabilityServiceCollection()
                            .AddDoctorAppointmentServiceCollection()
                            .AddAppointmentBookingInfrastructureServices()
                            .AddAppointmentConfirmationCore();

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