
using System.ComponentModel.DataAnnotations;
using StateHospital.Common;
using StateHospital.Presentation.Models;

namespace StateHospital.Presentation.Models
{
    public class DoctorModel : BaseModel
    {
        public int DoctorId { get; set; }
        public int DoctorRegistrationId { get; set; }
        public string? Name { get; set; }
        public string? Qualification { get; set; }
        public DoctorSpecialization Specialization { get; set; }
        public string? PhoneNumber { get; set; }
        public string? City { get; set; }
    }
}
