//References
using System.ComponentModel.DataAnnotations;
namespace ClinicaAPI.DTOs
{
    public class PatientCreateDTO
    {
        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(50)]
        public string Apellido { get; set; }

        [Required]
        public DateTime FechaNacimiento { get; set; }

        [Required]
        [StringLength(10)]
        public string Genero { get; set; }

        [Required]
        [Phone]
        public string Telefono { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [EmailAddress]
        [Compare("Email", ErrorMessage = "Los correos electrónicos no coinciden.")]
        public string ConfirmEmail { get; set; }

        [Required]
        [StringLength(200)]
        public string Direccion { get; set; }
    }
}
