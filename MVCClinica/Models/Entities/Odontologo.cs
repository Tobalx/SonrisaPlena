namespace ClinicaSonrrisaPlena.Models.Entities
{
    public class Odontologo: Persona
    {
        public string Matricula { get; set; }
        public string Especialidad { get; set; }

        public ICollection<Turno> Turnos { get; set; } = new List<Turno>();
        public ICollection<HistorialTratamiento> Historiales { get; set; } = new List<HistorialTratamiento>();
        public ICollection<PlanTratamiento> Planes { get; set; } = new List<PlanTratamiento>();
    }
}
