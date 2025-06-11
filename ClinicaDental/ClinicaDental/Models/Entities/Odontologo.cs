namespace ClinicaDental.Models.Entities
{
    public class Odontologo
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Matricula { get; set; }
        public string Especialidad { get; set; }
        public string Correo { get; set; }

        public List<Turno> Turnos { get; set; }
        public List<PlanTratamiento> PlanesTratamiento { get; set; }
    }
}
