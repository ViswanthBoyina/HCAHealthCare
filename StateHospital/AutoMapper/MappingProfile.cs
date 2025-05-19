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
            CreateMap<Slot, SlotModel>().ReverseMap();

            CreateMap<Appointment, AppointmentModel>()
                .ForMember(dest => dest.DoctorName, opt => opt.MapFrom(src => src.Doctor != null ? src.Doctor.Name : string.Empty))
                .ForMember(dest => dest.PatientName, opt => opt.MapFrom(src => src.Patient != null ? src.Patient.Name : string.Empty))
                .ReverseMap();
        }
    }
}
