using StateHospital.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateHospital.Services.Interfaces
{
    public interface ISlotService
    {
        Task<IEnumerable<Slot>> GetAllSlotsAsync();
        Task<Slot?> GetSlotByIdAsync(int id);
    }
}
