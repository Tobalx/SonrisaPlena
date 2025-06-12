namespace ClinicaDental.Models.Entities
{
    public class Recepcionista
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }

        public List<Turno> Turnos { get; set; }
        public Usuario Usuario { get; set; }

    }
}
