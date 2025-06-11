namespace ClinicaDental.Models.Entities
{
    public class Turno
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan Hora { get; set; }
        public int DuracionMinutos  { get; set; }
        public string Estato { get; set; }
        public int PacienteId { get; set; }
        public Paciente Paciente { get; set; }
        public int OdontologoId { get; set; }
        public Odontologo Odontologo { get; set; }


    }
}
