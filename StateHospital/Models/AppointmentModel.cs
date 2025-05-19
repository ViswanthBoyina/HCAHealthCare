namespace StateHospital.Presentation.Models
{
    public class AppointmentModel : BaseModel
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public string DoctorName { get; set; } = string.Empty;
        public string? DoctorSpecialization { get; set; }

        public int PatientId { get; set; }
        public string PatientName { get; set; } = string.Empty;

        public int SlotId { get; set; }
        public string SlotTime { get; set; } = string.Empty;

        public bool Status { get; set; }
        public DateTime BookedDate { get; set; }
    }
}
