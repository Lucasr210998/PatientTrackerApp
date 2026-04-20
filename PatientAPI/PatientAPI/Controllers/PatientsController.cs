using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PatientAPI.Data;
using PatientAPI.Models;
using System.Threading.Tasks;

namespace PatientAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        //static private List<Patient> Patients = new List<Patient>
        //{
        //    new Patient
        //    {
        //        Id = 1,
        //        FirstName = "Patient",
        //        LastName = "One",
        //        Age = 24,
        //        Symptoms = "Headache, nausea, cramps",
        //        BedNumber = 542
        //    },
        //    new Patient
        //    {
        //        Id = 2,
        //        FirstName = "Patient",
        //        LastName = "Two",
        //        Age = 35,
        //        Symptoms = "Skin irritation, nausea, vision impairment",
        //        BedNumber = 975
        //    },
        //    new Patient
        //    {
        //        Id = 3,
        //        FirstName = "Patient",
        //        LastName = "Three",
        //        Age = 18,
        //        Symptoms = "Skin irritation, nausea, vision impairment",
        //        BedNumber = 645
        //    },
        //    new Patient
        //    {
        //        Id = 4,
        //        FirstName = "Patient",
        //        LastName = "Four",
        //        Age = 85,
        //        Symptoms = "Fainting, nausea, trouble walking",
        //        BedNumber = 645
        //    },

        //};

        private readonly PatientAPIContext _context;
        public PatientsController(PatientAPIContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Patient>>> GetPatients()
        {
            return Ok(await _context.Patients.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Patient>> GetPatient(int id)
        {
            var patient = await _context.Patients.FindAsync(id);

            if (patient == null)
            {
                return NotFound();
            }

            return Ok(patient);
        }

        [HttpPost]
        public async Task<ActionResult> PostPatient(Patient newPatient)
        {
            if (newPatient == null)
            {
                return BadRequest();
            }

            _context.Patients.Add(newPatient);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPatient), new { id = newPatient.Id }, newPatient);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePatient(int id,  Patient updatedPatient)
        {
            var patient = await _context.Patients.FindAsync(id);

            if (patient == null)
            {
                return NotFound();
            }

            patient.Id = updatedPatient.Id;
            patient.FirstName = updatedPatient.FirstName;
            patient.LastName = updatedPatient.LastName;
            patient.Age = updatedPatient.Age;
            patient.Symptoms = updatedPatient.Symptoms;
            patient.BedNumber = updatedPatient.BedNumber;

            await _context.SaveChangesAsync();

            return NoContent();

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePatient(int id)
        {
            var patient = await _context.Patients.FindAsync(id);

            if (patient == null)
            {
                return NotFound();
            }

            _context.Patients.Remove(patient);
            await _context.SaveChangesAsync();

            return NoContent();

        }
    }
}
