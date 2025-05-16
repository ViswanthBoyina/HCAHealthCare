using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using StateHospital.Data;
using StateHospital.Data.Entities;
using StateHospital.Services.Interfaces;

namespace StateHospital.Services.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private string? CurrentUserName => _httpContextAccessor.HttpContext?.User?.Identity?.Name ?? "system";

        public DoctorService(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IEnumerable<Doctor>> GetAllDoctorsAsync()
        {
            return await _context
                         .Doctors
                         .ToListAsync();
        }

        public async Task<Doctor?> GetDoctorByIdAsync(int id)
        {
            return await _context
                         .Doctors
                         .FirstOrDefaultAsync(dr => dr.DoctorId == id);
        }

        public async Task AddDoctorAsync(Doctor doctor)
        {
            if (doctor == null) 
                throw new ArgumentNullException(nameof(doctor));

            doctor.CreatedDate = DateTime.UtcNow;
            doctor.CreatedBy = CurrentUserName;
            doctor.LastModifiedDate = DateTime.UtcNow;
            doctor.LastModifiedBy = CurrentUserName;

            await _context.Doctors.AddAsync(doctor);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateDoctorAsync(Doctor doctor)
        {
            var existingDoctor = await _context.Doctors.FindAsync(doctor.DoctorId);
            if (existingDoctor == null) return;

            // Update fields
            existingDoctor.Name = doctor.Name;
            existingDoctor.Qualification = doctor.Qualification;
            existingDoctor.Specialization = doctor.Specialization;
            existingDoctor.City = doctor.City;
            existingDoctor.DoctorId = doctor.DoctorId;
            existingDoctor.PhoneNumber = doctor.PhoneNumber;
            existingDoctor.DoctorRegistrationId = doctor.DoctorRegistrationId;
            existingDoctor.LastModifiedDate = DateTime.UtcNow;
            existingDoctor.LastModifiedBy = CurrentUserName;

            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteDoctorAsync(int id)
        {
            var doctor = await _context.Doctors.FindAsync(id);
            if (doctor == null) return false;

            _context.Doctors.Remove(doctor);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
