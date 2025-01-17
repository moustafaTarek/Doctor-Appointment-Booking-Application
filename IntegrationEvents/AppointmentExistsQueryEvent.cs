using MediatR;

namespace Integration.Events
{
    public class AppointmentExistsQueryEvent : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
