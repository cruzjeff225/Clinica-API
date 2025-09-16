//Reference to Models
using ClinicaAPI.Models;

namespace ClinicaAPI.Repositories
{
    public interface IPatientRepository
    {
        Task<IEnumerable<Patient>> GetAllAsync();
        Task<Patient?> GetByIdAsync(int id);
        Task<Patient> AddAsync(Patient patient);
        Task<Patient> UpdateAsync(int id, Patient patient);
        Task<bool> DeleteAsync(int id);
        Task<Patient?> GetByEmailAsync(string email);
    }
}
