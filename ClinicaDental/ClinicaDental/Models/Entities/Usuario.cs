namespace ClinicaDental.Models.Entities
{
    public class Usuario
    {
        public int Id { get; set; }
        public string NombreUsuario { get; set; }
        public string Contrasena { get; set; }
        public int RolId { get; set; }

        // Campos opcionales que permiten enlazar al usuario con uno de los roles concretos
        public int? PacienteId { get; set; }
        public int? OdontologoId { get; set; }
        public int? AdministradorId { get; set; }
        public int? RecepcionistaId { get; set; }

        // Relaciones
        public Rol Rol { get; set; }
        public Paciente Paciente { get; set; }
        public Odontologo Odontologo { get; set; }
        public Administrador Administrador { get; set; }
        public Recepcionista Recepcionista { get; set; }
    }

}
