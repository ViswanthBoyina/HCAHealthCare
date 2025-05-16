namespace StateHospital.Presentation.Models
{
    public class AppointmentModel : BaseModel
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public int SlotId { get; set; }
        public bool Status { get; set; }     // 1 - Booked, 0 - Not Booked
        public DateTime BookedDate { get; set; }

    }
}
