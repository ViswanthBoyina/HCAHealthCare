using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using StateHospital.Data;
using StateHospital.Data.Entities;
using StateHospital.Services.Interfaces;
using System.Numerics;

namespace StateHospital.Services.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private string? CurrentUserName => _httpContextAccessor.HttpContext?.User?.Identity?.Name ?? "system";


        public AppointmentService(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IEnumerable<Appointment>> GetAllAppointmentsAsync()
        {
            return await _context.Appointments
                         .Include(a => a.Doctor)
                         .Include(a => a.Patient)
                         .ToListAsync();
        }

        public async Task<Appointment?> GetAppointmentByIdAsync(int id)
        {
            return await _context
                         .Appointments
                         .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task AddAppointmentAsync(Appointment appointment)
        {
            if (appointment == null)
                throw new ArgumentNullException(nameof(appointment));

            appointment.CreatedDate = DateTime.UtcNow;
            appointment.CreatedBy = CurrentUserName;
            appointment.LastModifiedDate = DateTime.UtcNow;
            appointment.LastModifiedBy = CurrentUserName;

            appointment.Doctor = null;
            appointment.Patient = null;
            await _context.Appointments.AddAsync(appointment);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteAppointmentAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAppointmentAsync(Appointment appointment)
        {
            throw new NotImplementedException();
        }
    }
}
