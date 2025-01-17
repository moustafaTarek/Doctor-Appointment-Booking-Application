using Integration.DTOs;
using MediatR;

namespace Integration.Events
{
    public class AppointmentsGetQueryEvent : IRequest<IList<AppointmentGetQueryResponse>>
    {
        public Guid DoctorId { get; set; }
    }
}