namespace ClinicaDental.Models.Entities
{
    public class Paciente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Rut { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }

        public string Direccion { get; set; }
        
        public List<Turno> Turnos { get; set; }
        public List <PlanTratamiento> PlanesTratamiento { get; set; }
    }
}
