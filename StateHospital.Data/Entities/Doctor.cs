using StateHospital.Common;
using StateHospital.Data.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateHospital.Data.Entities
{
    public class Doctor : IEntity
    {
        public int DoctorId { get; set; }
        public int DoctorRegistrationId { get; set; }
        public string? Name { get; set; }
        public string? Qualification { get; set; }
        public DoctorSpecialization Specialization { get; set; }
        public string? PhoneNumber { get; set; }
        public string? City { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
    }
}
