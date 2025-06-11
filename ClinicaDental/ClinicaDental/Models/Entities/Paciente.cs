namespace ClinicaDental.Models.Entities
{
    public class Paciente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string RUT { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }

        // Relación uno a muchos con Turno (un paciente puede tener muchos turnos)
        public ICollection<Turno> Turnos { get; set; }

        // Relación uno a muchos con EjecucionTratamiento (un paciente puede tener múltiples tratamientos ejecutados)
        public ICollection<EjecucionTratamiento> EjecucionesTratamiento { get; set; }
    }

}
