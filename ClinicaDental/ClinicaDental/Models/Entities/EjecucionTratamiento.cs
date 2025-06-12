namespace ClinicaDental.Models.Entities
{
    public class EjecucionTratamiento
    {
        public int Id { get; set; }
        public int PacienteId { get; set; }
        public Paciente Paciente { get; set; }
        public int OdontologoId { get; set; }
        public Odontologo Odontologo { get; set; }

        public DateTime FechaEstimada { get; set; }
        public DateTime? FechaRealizacion { get; set; }
        public string Estado { get; set; }
        public string Observaciones { get; set; }
        public string ObservacionesGenerales { get; set; }

        public ICollection<EjecucionTratamientoDetalle> EjecucionTratamientoDetalles { get; set; }
        public ICollection<TratamientoPorTurno> TratamientosPorTurno { get; set; }
    }
}
