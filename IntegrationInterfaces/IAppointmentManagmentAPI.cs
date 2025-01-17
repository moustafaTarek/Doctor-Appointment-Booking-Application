namespace Integration.Interfaces
{
    public interface IAppointmentManagmentAPI
    {
        Task<string> MarkAppointment(Guid appoitmentId, short appointmentStatusId);
    }
}
