namespace ClinicaDental.Models.Entities
{
    public class Turno
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan Hora { get; set; }
        public int DuracionMinutos { get; set; }
        public string Estado { get; set; } //Pendiente,Confirmado,Realizado,Cancelado

        public int PacienteId { get; set; }
        public int OdontologoId { get; set; }
        public int RecepcionistaId { get; set; }

        // Relaciones muchos a uno con Paciente, Odontologo y Recepcionista
        public Paciente Paciente { get; set; }
        public Odontologo Odontologo { get; set; }
        public Recepcionista Recepcionista { get; set; }

        // Relación uno a muchos con TratamientoPorTurno (un turno puede tener varios pasos de tratamiento)
        public List<TratamientoPorTurno> TratamientosPorTurno { get; set; }
    }

}
