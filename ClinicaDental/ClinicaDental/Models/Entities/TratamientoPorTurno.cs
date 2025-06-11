namespace ClinicaDental.Models.Entities
{
    public class TratamientoPorTurno
    {
        public int Id { get; set; }
        public int TurnoId { get; set; }
        public int EjecucionTratamientoId { get; set; }
        public string EstadoPaso { get; set; } //Pendiente,En Progreso, Realizado, Cancelado
        public string ObservacionesTurno { get; set; }

        // Relaciones muchos a uno
        public Turno Turno { get; set; }
        public EjecucionTratamiento EjecucionTratamiento { get; set; }
    }

}
