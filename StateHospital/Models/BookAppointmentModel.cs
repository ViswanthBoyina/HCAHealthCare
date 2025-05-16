using StateHospital.Data.Entities;

namespace StateHospital.Presentation.Models
{
    public class BookAppointmentModel
    {
        public DoctorModel? Doctor { get; set; }
        public IEnumerable<Slot>? Slots { get; set; }
        public IEnumerable<Patient>? Patients { get; set; }
        public AppointmentModel? Appointment { get; set; }
    }
}
