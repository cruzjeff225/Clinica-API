// References to Models, Services  and ASP.NET Core
using ClinicaAPI.Models;
using ClinicaAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ClinicaAPI.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class PatientController : ControllerBase
    {
        private readonly PatientService _service;

        public PatientController(PatientService service)
        {
            _service = service;
        }

        // GET: api/patient
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var patients = await _service.GetAllAsync();
            return Ok(patients);
        }

        // GET: api/patient/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var patient = await _service.GetByIdAsync(id);
            if (patient == null)
            {
                return NotFound();
            }
            return Ok(patient);
        }

        // POST: api/patient
        [HttpPost]
        public async Task<IActionResult> Create(Patient patient)
        {
            var newPatient = await _service.AddAsync(patient);
            return CreatedAtAction(nameof(GetById), new { id = newPatient.ID }, newPatient);
        }

        // PUT: api/patient/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Patient patient)
        {
            if (id != patient.ID)
            {
                return BadRequest();
            }
            var updatedPatient = await _service.UpdateAsync(id, patient);
            return Ok(updatedPatient);
        }

        // DELETE: api/patient/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
