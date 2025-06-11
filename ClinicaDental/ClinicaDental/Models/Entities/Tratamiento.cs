namespace ClinicaDental.Models.Entities
{
    public class Tratamiento
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int CreadoPorAdministradorId { get; set; }
        public DateTime FechaCreacion { get; set; }

        // Relación muchos a uno con Administrador
        public Administrador CreadoPorAdministrador { get; set; }

        // Relación uno a muchos con EjecucionTratamiento
        public ICollection<EjecucionTratamiento> EjecucionesTratamiento { get; set; }
    }
}
