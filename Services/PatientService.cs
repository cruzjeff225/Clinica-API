// References to Models and Repositories
using ClinicaAPI.Models;
using ClinicaAPI.Repositories;

namespace ClinicaAPI.Services
{
    public class PatientService
    {
        private readonly IPatientRepository _repository;

        public PatientService(IPatientRepository repository)
        {
            _repository = repository;
        }

        // Methods for CRUD operations
        public Task<IEnumerable<Patient>> GetAllAsync() => _repository.GetAllAsync();
        public Task<Patient?> GetByIdAsync(int id) => _repository.GetByIdAsync(id);
        public async Task<Patient> AddAsync(Patient patient)
        {
            // Email validation before adding a new patient
            var existingPatient = await _repository.GetByEmailAsync(patient.Email);
            if (existingPatient != null)
            {
                throw new ArgumentException("El correo electrónico que deseas usar ya está en uso.");
            }
            return await _repository.AddAsync(patient);
        }
        public Task<Patient> UpdateAsync(int id, Patient patient) => _repository.UpdateAsync(id, patient);
        public Task<bool> DeleteAsync(int id) => _repository.DeleteAsync(id);
    }
}
