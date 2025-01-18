using MediatR;

namespace Integration.Events
{
    public class AppoitmentConfirmationQueryEvent : IRequest<string>
    {
        public Guid AppointmentId { get; set; }
    }
}
