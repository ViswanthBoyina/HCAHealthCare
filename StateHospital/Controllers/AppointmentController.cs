using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using StateHospital.Data.Entities;
using StateHospital.Models;
using StateHospital.Presentation.Models;
using StateHospital.Services.Interfaces;

namespace StateHospital.Presentation.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly IDoctorService _doctorService;
        private readonly IPatientService _patientService;
        private readonly ISlotService _slotService;
        private readonly IAppointmentService _appointmentService;
        private readonly IMapper _mapper;

        public AppointmentController(IDoctorService doctorService, IPatientService patientService, ISlotService slotService, IAppointmentService appointmentService, IMapper mapper)
        {
            _doctorService = doctorService;
            _patientService = patientService;
            _slotService = slotService;
            _appointmentService = appointmentService;
            _mapper = mapper;
        }

        // GET: Show all doctors
        public async Task<IActionResult> Index()
        {
            var doctors = await _doctorService.GetAllDoctorsAsync();
            var models = _mapper.Map<IEnumerable<DoctorModel>>(doctors);
            return View(models);
        }

        // GET: Book appointment
        public async Task<IActionResult> BookAppointment(int doctorId)
        {
            var doctor = await _doctorService.GetDoctorByIdAsync(doctorId);
            var slots = await _slotService.GetAllSlotsAsync();
            var patients = await _patientService.GetAllPatientsAsync();

            var doctorModel = _mapper.Map<DoctorModel>(doctor);
            var slotModels = _mapper.Map<IEnumerable<SlotModel>>(slots);
            var patientModels = _mapper.Map<IEnumerable<PatientModel>>(patients);


            ViewBag.DoctorModel = doctorModel;
            ViewBag.Slots = new SelectList(slotModels, "SlotId", "SlotTime");
            ViewBag.Patients = new SelectList(patientModels, "Id", "Name");
            return View();
        }

        // POST: Book appointment
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> BookAppointment(AppointmentModel model)
        {
            if (ModelState.IsValid)
            {
                model.BookedDate = DateTime.UtcNow;
                model.Status = true;
                await _appointmentService.AddAppointmentAsync(_mapper.Map<Appointment>(model));
                return RedirectToAction("Index");
            }

            // In case of validation failure, repopulate dropdowns
            ViewBag.Slots = new SelectList(await _slotService.GetAllSlotsAsync(), "SlotId", "SlotTime");
            ViewBag.Patients = new SelectList(await _patientService.GetAllPatientsAsync(), "Id", "Name");

            return View(model);
        }
    }
}