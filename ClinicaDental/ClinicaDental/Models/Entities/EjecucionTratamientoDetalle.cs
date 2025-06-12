namespace ClinicaDental.Models.Entities
{
    public class EjecucionTratamientoDetalle
    {
        public int Id { get; set; }
        public int EjecucionTratamientoId { get; set; }
        public EjecucionTratamiento EjecucionTratamiento { get; set; }

        public int TratamientoId { get; set; }
        public Tratamiento Tratamiento { get; set; }
    }
}
