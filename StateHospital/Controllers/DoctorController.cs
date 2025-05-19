using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StateHospital.Data.Entities;
using StateHospital.Models;
using StateHospital.Presentation.Models;
using StateHospital.Services.Interfaces;
using StateHospital.Services.Services;

namespace StateHospital.Presentation.Controllers
{
    public class DoctorController : Controller
    {
        private readonly IDoctorService _doctorService;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        private string? CurrentUserName => _httpContextAccessor.HttpContext?.User?.Identity?.Name ?? "system";

        public DoctorController(IDoctorService doctorService, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _doctorService = doctorService;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IActionResult> Index()
        {
            var doctors = await _doctorService.GetAllDoctorsAsync();
            var models = _mapper.Map<IEnumerable<DoctorModel>>(doctors);
            return View(models);
        }

        // GET: Doctor/Details/5
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var doctor = await _doctorService.GetDoctorByIdAsync(id);
            if (doctor == null)
            {
                return NotFound();
            }

            var doctorModel = _mapper.Map<DoctorModel>(doctor);
            return View(doctorModel);
        }

        // GET: Patient/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PatientController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(DoctorModel model)
        {
            if (ModelState.IsValid)
            {
                model.CreatedDate = DateTime.UtcNow;
                model.LastModifiedDate = DateTime.UtcNow;
                model.CreatedBy = CurrentUserName;
                model.LastModifiedBy = CurrentUserName;

                var doctor = _mapper.Map<Doctor>(model);
                await _doctorService.AddDoctorAsync(doctor);

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var doctor = await _doctorService.GetDoctorByIdAsync(id);
            if (doctor == null) 
                return NotFound();

            var model = _mapper.Map<DoctorModel>(doctor);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(DoctorModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = await _doctorService.GetDoctorByIdAsync(model.DoctorId);
            if (result == null)
            {
                return NotFound();
            }

            model.LastModifiedDate = DateTime.UtcNow;
            model.LastModifiedBy = CurrentUserName;

            var updatedEntity = _mapper.Map<Doctor>(model);
            await _doctorService.UpdateDoctorAsync(updatedEntity);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var doctor = await _doctorService.GetDoctorByIdAsync(id);
            if (doctor == null)
            {
                return NotFound();
            }

            var model = _mapper.Map<DoctorModel>(doctor);
            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _doctorService.DeleteDoctorAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
