namespace ClinicaDental.Models.Entities
{
    public class Odontologo
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Matricula { get; set; }
        public string Especialidad { get; set; }
        public string Email { get; set; }
        public int CreadoPorAdministradorId { get; set; }
        public DateTime FechaCreacion { get; set; }

        // Relación muchos a uno con Administrador (el administrador que creó al odontólogo)
        public Administrador CreadoPorAdministrador { get; set; }

        // Relación uno a muchos con Turno (un odontólogo puede tener varios turnos asignados)
        public List<Turno> Turnos { get; set; }

        // Relación uno a muchos con EjecucionTratamiento (un odontólogo ejecuta varios tratamientos)
        public List<EjecucionTratamiento> EjecucionesTratamiento { get; set; }
        public Usuario Usuario { get; set; }
    }

}
