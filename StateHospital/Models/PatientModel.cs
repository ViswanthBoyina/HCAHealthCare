using StateHospital.Common;
using StateHospital.Presentation.Models;

namespace StateHospital.Models
{
    public class PatientModel : BaseModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public Gender Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public string? Diagnosis { get; set; }
        public bool IsDeleted { get; set; }
    }
}
