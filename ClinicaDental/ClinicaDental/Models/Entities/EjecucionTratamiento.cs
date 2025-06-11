namespace ClinicaDental.Models.Entities
{
    public class EjecucionTratamiento
    {
        public int Id { get; set; }
        public int PacienteId { get; set; }
        public int OdontologoId { get; set; }
        public int TratamientoId { get; set; }
        public DateTime FechaEstimada { get; set; }
        public DateTime? FechaRealizacion { get; set; }
        public string Estado { get; set; } //Pendiente,Confirmado,Realizado,Cancelado
        public string Observaciones { get; set; }
        public string ObservacionesGenerales { get; set; }

        // Relaciones muchos a uno
        public Paciente Paciente { get; set; }
        public Odontologo Odontologo { get; set; }
        public Tratamiento Tratamiento { get; set; }

        // Relación uno a muchos con TratamientoPorTurno
        public ICollection<TratamientoPorTurno> TratamientosPorTurno { get; set; }
    }
}
