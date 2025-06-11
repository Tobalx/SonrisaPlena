namespace ClinicaDental.Models.Entities
{
    public class PlanTratamiento
    {
        public int Id { get; set; }
        public DateTime FechaInicio { get; set; }
        public int PacienteId { get; set; }
        public Paciente Paciente { get; set; }
        public int OdontologoId { get; set; }
        public Odontologo Odontologo { get; set; }

        public List<PasoTratamiento> Pasos { get; set; }
    }
}
