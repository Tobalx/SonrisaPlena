namespace ClinicaDental.Models.Entities
{
    public class Recepcionista
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }

        // Relación uno a muchos con Turno (una recepcionista puede agendar muchos turnos)
        public ICollection<Turno> Turnos { get; set; }
    }

}
