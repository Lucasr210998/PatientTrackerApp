using Microsoft.AspNetCore.Mvc;
using PatientTracker.Models;
using PatientTracker.Services;

namespace PatientTracker.Controllers
{
    public class PatientsController : Controller
    {
        private readonly PatientAPIService _api;

        public PatientsController(PatientAPIService api)
        {
            _api = api;
        }

        public async Task<IActionResult> Index()
        {
            var patients = await _api.GetPatientsAsync();
            return View(patients);
        }

        public async Task<IActionResult> Details(int id)
        {
            var patient = await _api.GetPatientAsync(id);
            return View(patient);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Patient patient)
        {
            if (!ModelState.IsValid)
            {
                return View(patient);
            }

            await _api.CreatePatientAsync(patient);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var patient = await _api.GetPatientAsync(id);
            return View(patient);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Patient patient)
        {
            await _api.UpdatePatientAsync(id, patient);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var patient = await _api.GetPatientAsync(id);
            return View(patient);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _api.DeletePatientAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }

}
