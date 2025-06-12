namespace ClinicaDental.Models.Entities
{
    public class Administrador
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }

        // Relación uno a muchos con Odontologo (un administrador puede crear varios odontólogos)
        public ICollection<Odontologo> Odontologos { get; set; }
        // Relación uno a muchos con Tratamiento (un administrador puede crear varios tratamientos)
        public ICollection<Tratamiento> Tratamientos { get; set; }
        public Usuario Usuario { get; set; }

    }

}
