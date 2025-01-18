using Integration.Events;
using MediatR;

namespace Appointment.Confirmation.Core.Handlers
{
    internal class NotificationServiceHandler : IRequestHandler<AppoitmentConfirmationQueryEvent, string>
    {
        public async Task<string> Handle(AppoitmentConfirmationQueryEvent request, CancellationToken cancellationToken)
        {
            Console.WriteLine($"Appointment with Id: {request.AppointmentId} has been confirmed successfully");

            return "Done";
        }
    }
}
