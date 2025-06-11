namespace ClinicaDental.Models.Entities
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Clave { get; set; } // contrasena
        public string Rol { get; set; }
        public int? PacienteId { get; set; }
        public Paciente Paciente { get; set; }
        public int? OdontologoId { get; set; }
        public Odontologo Odontologo { get; set; }
        public int? AdministradorId { get; set; }
        public Administrador Administrador { get; set; }

    }
}
