using DoctorEntity = Doctor.Availability.DataAccess.Entities.Doctor;
namespace Doctor.Availability.Core.Doctor.DoctorDtos
{
    public class DoctorGetResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public static DoctorGetResponse Of(DoctorEntity doctor)
        {
            return new DoctorGetResponse
            {
                Id = doctor.Id,
                Name = doctor.Name,
            };
        }
    }
}
