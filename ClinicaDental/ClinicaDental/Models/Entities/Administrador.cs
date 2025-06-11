namespace ClinicaDental.Models.Entities
{
    public class Administrador
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }

        // Relación uno a muchos con Odontologo (un administrador puede crear varios odontólogos)
        public ICollection<Odontologo> OdontologosCreados { get; set; }

        // Relación uno a muchos con Tratamiento (un administrador puede crear varios tratamientos)
        public ICollection<Tratamiento> TratamientosCreados { get; set; }
    }

}
