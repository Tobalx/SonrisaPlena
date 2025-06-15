using System.ComponentModel.DataAnnotations;

namespace ClinicaSonrrisaPlena.Models.Entities
{
    public abstract class Persona
    {
        public int Id { get; set; }
        public required string Nombre { get; set; }
        public required string Email { get; set; } 
        public required string Clave { get; set; }
        public required string Rol { get; set; }
    }
}
