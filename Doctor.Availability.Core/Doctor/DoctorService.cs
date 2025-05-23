﻿using Doctor.Availability.DataAccess.Repositories;

namespace Doctor.Availability.Core.Doctor
{
    internal class DoctorService
    {
        private readonly DoctorRepository _doctorRepository;

        public DoctorService(DoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        public async Task CheckIfNotExists(Guid doctorId)
        {
            var isExists = await _doctorRepository.CheckIfExists(doctorId);

            if (!isExists)
                throw new ArgumentNullException($"Doctor with Id: {doctorId} not exists");
        }

        public async Task<DataAccess.Entities.Doctor> GetIfExists(Guid doctorId)
        {
            return await _doctorRepository.GetById(doctorId) ?? throw new ArgumentNullException($"No doctors have been found with Id: {doctorId}");
        }

        public async Task<Guid> AddDoctor(string doctorName)
        {
            var doctor = new DataAccess.Entities.Doctor
            {
                Name = doctorName
            };
            
            await _doctorRepository.AddAsync(doctor);
            await _doctorRepository.SaveChangesAsync();

            return doctor.Id;
        }
    }
}