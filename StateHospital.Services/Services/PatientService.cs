using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using StateHospital.Data;
using StateHospital.Data.Entities;
using StateHospital.Services.Interfaces;

namespace StateHospital.Services.Services
{
    public class PatientService : IPatientService
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        private string? CurrentUserName
        {
            get { return _httpContextAccessor.HttpContext?.User?.Identity?.Name ?? "system"; }
        }

        public PatientService(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IEnumerable<Patient>> GetAllPatientsAsync()
        {
            return await _context.Patients
                         .Where(p => !p.IsDeleted)
                         .ToListAsync();
        }

        public async Task<Patient?> GetPatientByIdAsync(int id)
        {
            return await _context.Patients
                         .FirstOrDefaultAsync(p => p.Id == id && !p.IsDeleted);
        }

        public async Task AddPatientAsync(Patient patient)
        {
            if (patient == null)
            {
                throw new ArgumentNullException(nameof(patient));
            }

            _context.Patients.Add(patient);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePatientAsync(Patient patient)
        {
            if (patient == null)
            {
                throw new ArgumentNullException(nameof(patient));
            }

            var updatePatient = await _context.Patients.FindAsync(patient.Id);
            if (updatePatient == null)
            {
                return;
            }

            // Update only necessary fields
            updatePatient.Name = patient.Name;
            updatePatient.Gender = patient.Gender;
            updatePatient.DateOfBirth = patient.DateOfBirth;
            updatePatient.Phone = patient.Phone;
            updatePatient.Address = patient.Address;
            updatePatient.Diagnosis = patient.Diagnosis;
            updatePatient.LastModifiedBy = CurrentUserName;
            updatePatient.LastModifiedDate = DateTime.UtcNow;

            await _context.SaveChangesAsync();

        }

        public async Task<bool> DeletePatientAsync(int id)
        {
            var patient = await _context.Patients.FindAsync(id);
            if (patient == null)
            {
                return false;
            }

            patient.LastModifiedDate = DateTime.UtcNow;
            patient.LastModifiedBy = CurrentUserName;
            patient.IsDeleted = true;            // Soft delete
            //_context.Patients.Remove(patient); // Soft delete
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
