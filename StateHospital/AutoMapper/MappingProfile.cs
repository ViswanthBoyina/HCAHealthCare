using AutoMapper;
using StateHospital.Data.Entities;
using StateHospital.Models;
using StateHospital.Presentation.Models;

namespace StateHospital.Presentation.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Patient, PatientModel>().ReverseMap();
            CreateMap<Doctor, DoctorModel>().ReverseMap();
            CreateMap<Appointment, AppointmentModel>().ReverseMap();
            CreateMap<Slot, SlotModel>().ReverseMap();

        }
    }
}
