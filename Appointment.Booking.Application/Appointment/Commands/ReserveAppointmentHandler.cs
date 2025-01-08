
using Appointment.Booking.Domain.Exceptions;
using Appointment.Booking.Domain.IRepositories;
using Doctor.Availability.Core;
using System.Collections.Concurrent;
using AppointmentModel = Appointment.Booking.Domain.Models.Appointment;

namespace Appointment.Booking.Application.Appointment.Commands
{
    internal class ReserveAppointmentHandler
    {
        private readonly DoctorAvailabilityService _doctorAvailabilityService;
        private readonly IAppointmentRepo _appointmentRepo;

        private static readonly ConcurrentDictionary<Guid, SemaphoreSlim> _slotLocks = new ConcurrentDictionary<Guid, SemaphoreSlim>();

        public ReserveAppointmentHandler(DoctorAvailabilityService doctorAvailabilityService, IAppointmentRepo appointmentRepo)
        {
            _doctorAvailabilityService = doctorAvailabilityService;
            _appointmentRepo = appointmentRepo;
        }

        public async Task<string> Handle(AppointmentReservationRequest command) 
        {
            var slotLock = _slotLocks.GetOrAdd(command.SlotId, _ => new SemaphoreSlim(1, 1));
            await slotLock.WaitAsync();

            try
            {
                var slot = await _doctorAvailabilityService.GetSlot(command.SlotId) ?? throw new ArgumentNullException($"No slots has been found for Id: {command.SlotId}", "Slot");

                if (slot.IsReserved)
                    throw new InvalidReservationException($"Slot has been reserved already");

                if(!slot.DoctorId.Equals(command.DoctorId))
                    throw new InvalidReservationException($"Slot does not belong to the doctor with Id: {slot.DoctorId}");

                var appointment = AppointmentModel.Create(command.DoctorId, command.PatientId, command.SlotId);

                await _appointmentRepo.AddAppointment(appointment);

                return $"Appointment has been reserved successfully with Id: {appointment.Id}";
            }
            finally
            {
                slotLock.Release();
                if (slotLock.CurrentCount == 1)
                {
                    _slotLocks.TryRemove(command.SlotId, out _);
                }
            }
        }
    }
}
