using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StateHospital.Data.Entities;
using StateHospital.Models;
using StateHospital.Services.Interfaces;
using System.Threading.Tasks;

namespace StateHospital.Presentation.Controllers
{
    public class PatientController : Controller
    {
        private readonly IPatientService _patientService;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        private string? CurrentUserName => _httpContextAccessor.HttpContext?.User?.Identity?.Name ?? "system";

        public PatientController(IPatientService patientService, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _patientService = patientService;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        // GET: Get all patients
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var patients = await _patientService.GetAllPatientsAsync();
            var patientModels = _mapper.Map<IEnumerable<PatientModel>>(patients);
            return View(patientModels);
        }

        // GET: Patient/Details/5
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var patient = await _patientService.GetPatientByIdAsync(id);
            if (patient == null)
            {
                return NotFound();
            }

            var patientModel = _mapper.Map<PatientModel>(patient);
            return View(patientModel);
        }

        // GET: Patient/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PatientController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(PatientModel model)
        {
            if (ModelState.IsValid)
            {
                model.CreatedDate = DateTime.UtcNow;
                model.LastModifiedDate = DateTime.UtcNow;
                model.CreatedBy = CurrentUserName;
                model.LastModifiedBy = CurrentUserName;

                var patient = _mapper.Map<Patient>(model);
                await _patientService.AddPatientAsync(patient);

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var patient = await _patientService.GetPatientByIdAsync(id);
            if (patient == null)
            {
                return NotFound();
            }

            var model = _mapper.Map<PatientModel>(patient);
            return View(model);
        }

        // POST: PatientController/Update/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(PatientModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = await _patientService.GetPatientByIdAsync(model.Id);
            if (result == null)
            {
                return NotFound();
            }

            model.LastModifiedDate = DateTime.UtcNow;
            model.LastModifiedBy = CurrentUserName;

            var updatedEntity = _mapper.Map<Patient>(model);
            await _patientService.UpdatePatientAsync(updatedEntity);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var patient = await _patientService.GetPatientByIdAsync(id);
            if (patient == null)
            {
                return NotFound();
            }

            var model = _mapper.Map<PatientModel>(patient);
            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _patientService.DeletePatientAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
