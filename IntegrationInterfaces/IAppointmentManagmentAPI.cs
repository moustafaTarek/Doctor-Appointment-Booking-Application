namespace Integration.Interfaces
{
    public interface IAppointmentManagmentAPI
    {
        Task<string> MarkAppointment(Guid appointmentId, short appointmentStatusId);
    }
}
