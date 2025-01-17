using Integration.DTOs;
using MediatR;

namespace Integration.Events
{
    public class DoctorAvailableSlotsQueryEvent : IRequest<DoctorAvailableSlotsResponse>
    {
        public Guid DoctorId { get; set; }
    }
    
}
