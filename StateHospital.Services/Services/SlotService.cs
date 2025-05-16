using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using StateHospital.Data;
using StateHospital.Data.Entities;
using StateHospital.Services.Interfaces;

namespace StateHospital.Services.Services
{
    public class SlotService : ISlotService
    {
        private readonly ApplicationDbContext _context;

        public SlotService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Slot>> GetAllSlotsAsync()
        {
            return await _context.Slots
                         .ToListAsync();
        }

        public async Task<Slot?> GetSlotByIdAsync(int id)
        {
            return await _context.Slots
                         .Where(slot => slot.SlotId == id)
                         .FirstOrDefaultAsync();
        }
    }
}
