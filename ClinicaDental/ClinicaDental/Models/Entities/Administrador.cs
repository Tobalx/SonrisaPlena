using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ClinicaDental.Models.Entities
{
    [Index(nameof(Email), IsUnique = true)]
    public class Administrador
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El correo electrónico es obligatorio.")]
        [EmailAddress(ErrorMessage = "El formato del correo electrónico no es válido.")]
       
        public string Email { get; set; }

        // Relación uno a muchos con Odontologo (un administrador puede crear varios odontólogos)
        public ICollection<Odontologo> Odontologos { get; set; } = new List<Odontologo>();
        // Relación uno a muchos con Tratamiento (un administrador puede crear varios tratamientos)
        public ICollection<Tratamiento> Tratamientos { get; set; } = new List<Tratamiento>();

        public Usuario? Usuario { get; set; }
    }

}
