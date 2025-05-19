using System.ComponentModel.DataAnnotations;

namespace StateHospital.Common
{
    public enum DoctorSpecialization
    {
        [Display(Name = "Internal Medicine")]
        InternalMedicine,

        [Display(Name = "Pediatrics")]
        Pediatrics,

        [Display(Name = "Cardiology")]
        Cardiology,

        [Display(Name = "Dermatology")]
        Dermatology,

        [Display(Name = "Endocrinology")]
        Endocrinology,

        [Display(Name = "Gastroenterology")]
        Gastroenterology,

        [Display(Name = "Nephrology")]
        Nephrology,

        [Display(Name = "Neurology")]
        Neurology,

        [Display(Name = "Oncology")]
        Oncology,

        [Display(Name = "Pulmonology")]
        Pulmonology,

        [Display(Name = "Rheumatology")]
        Rheumatology,

        [Display(Name = "Allergy and Immunology")]
        AllergyAndImmunology,

        [Display(Name = "Anesthesiology")]
        Anesthesiology,

        [Display(Name = "Pathology")]
        Pathology,

        [Display(Name = "Psychiatry")]
        Psychiatry,

        [Display(Name = "Radiology")]
        Radiology,

        [Display(Name = "Surgery")]
        Surgery,

        [Display(Name = "Cardiothoracic Surgery")]
        CardiothoracicSurgery,

        [Display(Name = "Neurosurgery")]
        Neurosurgery,

        [Display(Name = "Orthopedic Surgery")]
        OrthopedicSurgery,

        [Display(Name = "Plastic Surgery")]
        PlasticSurgery,

        [Display(Name = "Urology")]
        Urology,

        [Display(Name = "Obstetrics and Gynecology")]
        ObstetricsAndGynecology,

        [Display(Name = "Ophthalmology")]
        Ophthalmology,

        [Display(Name = "ENT")]
        ENT,

        [Display(Name = "Dentistry")]
        Dentistry,

        [Display(Name = "Critical Care")]
        CriticalCare,

        [Display(Name = "Neonatology")]
        Neonatology
    }
}
