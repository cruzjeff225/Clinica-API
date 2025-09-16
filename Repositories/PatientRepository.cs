// Reference to Models, EFC and Config
using ClinicaAPI.Models;
using ClinicaAPI.Config;
using Microsoft.EntityFrameworkCore;

namespace ClinicaAPI.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly AppDbContext _context;

        public PatientRepository(AppDbContext context)
        {
            _context = context;
        }

        // Methods for CRUD operations
        // Method to get all patients
        public async Task<IEnumerable<Patient>> GetAllAsync()
        {
            return await _context.Patients.ToListAsync();
        }

        // Method to get a patient by ID
        public async Task<Patient?> GetByIdAsync(int id)
        {
            return await _context.Patients.FindAsync(id);
        }

        // Method to add a new patient
        public async Task<Patient> AddAsync(Patient patient)
        {
            _context.Patients.Add(patient);
            await _context.SaveChangesAsync();
            return patient;
        }

        // Method to update an existing patient
        public async Task<Patient> UpdateAsync(int id, Patient patient)
        {
            _context.Patients.Update(patient);
            await _context.SaveChangesAsync();
            return patient;
        }

        // Method to delete a patient by ID
        public async Task<bool> DeleteAsync(int id)
        {
            var patient = await _context.Patients.FindAsync(id);
            if (patient == null)
            {
                return false;
            }
            _context.Patients.Remove(patient);
            await _context.SaveChangesAsync();
            return true;
        }

        // Method to get a patient by email
        public async Task<Patient?> GetByEmailAsync(string email)
        {
            return await _context.Patients.FirstOrDefaultAsync(p => p.Email == email);
        }
    }
}
