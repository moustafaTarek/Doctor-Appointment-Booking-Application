
using Appointment.Booking.Domain.Exceptions;
using Appointment.Booking.Domain.IRepositories;
using Integration.Events;
using Integration.Interfaces;
using MediatR;
using System.Collections.Concurrent;
using AppointmentModel = Appointment.Booking.Domain.Models.Appointment;

namespace Appointment.Booking.Application.Appointment.Commands
{
    internal class ReserveAppointmentHandler : IRequestHandler<AppointmentReservationCommandEvent, string>
    {
        private readonly IDoctorAvailabilityAPI _doctorAvailabilityService;
        private readonly IAppointmentRepo _appointmentRepo;

        private static readonly ConcurrentDictionary<Guid, SemaphoreSlim> _slotLocks = new ConcurrentDictionary<Guid, SemaphoreSlim>();

        public ReserveAppointmentHandler(IDoctorAvailabilityAPI doctorAvailabilityService, IAppointmentRepo appointmentRepo)
        {
            _doctorAvailabilityService = doctorAvailabilityService;
            _appointmentRepo = appointmentRepo;
        }

        public async Task<string> Handle(AppointmentReservationCommandEvent request, CancellationToken cancellationToken)
        {
            var slotLock = _slotLocks.GetOrAdd(request.SlotId, _ => new SemaphoreSlim(1, 1));
            await slotLock.WaitAsync();
            try
            {
                var slot = await _doctorAvailabilityService.GetSlot(request.SlotId) ?? throw new ArgumentNullException($"No slots has been found for Id: {request.SlotId}", "Slot");

                if (slot.IsReserved)
                    throw new InvalidReservationException($"Slot has been reserved already");

                if (!slot.DoctorId.Equals(request.DoctorId))
                    throw new InvalidReservationException($"Slot does not belong to the doctor with Id: {slot.DoctorId}");
                var appointment = AppointmentModel.Create(request.DoctorId, request.PatientId, request.SlotId);
                await _doctorAvailabilityService.UpdateSlotAsReserved(slot.SlotId);

                await _appointmentRepo.AddAppointment(appointment);

                return $"Appointment has been reserved successfully with Id: {appointment.Id}";
            }
            finally
            {
                slotLock.Release();
                if (slotLock.CurrentCount == 1)
                {
                    _slotLocks.TryRemove(request.SlotId, out _);
                }
            }
        }
    }
}
