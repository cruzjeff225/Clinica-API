// References to Models, Services  and ASP.NET Core
using ClinicaAPI.DTOs;
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
        public async Task<ActionResult<PatientReadDTO>> GetById(int id)
        {
            var patient = await _service.GetByIdAsync(id);
            if (patient == null)
            {
                return NotFound();
            }

            // Map Patient to PatientReadDTO
            var result = new PatientReadDTO
            {
                ID = patient.ID,
                Nombre = patient.Nombre,
                Apellido = patient.Apellido,
                FechaNacimiento = patient.FechaNacimiento,
                Genero = patient.Genero,
                Telefono = patient.Telefono,
                Email = patient.Email,
                Direccion = patient.Direccion,
                FechaRegistro = patient.FechaRegistro
            };

            return Ok(result);
        }

        // POST: api/patient
        [HttpPost]
        public async Task<ActionResult<PatientReadDTO>> Create(PatientCreateDTO dto)
        {
            try
            {
                var patient = new Patient
                // Map DTO to Patient model
                {
                    Nombre = dto.Nombre,
                    Apellido = dto.Apellido,
                    FechaNacimiento = dto.FechaNacimiento,
                    Genero = dto.Genero,
                    Telefono = dto.Telefono,
                    Email = dto.Email,
                    Direccion = dto.Direccion,
                    FechaRegistro = DateTime.Now
                };

                var createdPatient = await _service.AddAsync(patient);

                // Map created Patient to PatientReadDTO
                var result = new PatientReadDTO
                {
                    ID = createdPatient.ID,
                    Nombre = createdPatient.Nombre,
                    Apellido = createdPatient.Apellido,
                    FechaNacimiento = createdPatient.FechaNacimiento,
                    Genero = createdPatient.Genero,
                    Telefono = createdPatient.Telefono,
                    Email = createdPatient.Email,
                    Direccion = createdPatient.Direccion,
                    FechaRegistro = createdPatient.FechaRegistro
                };

                return CreatedAtAction(nameof(GetById), new { id = result.ID }, result);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
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
