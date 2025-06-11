namespace ClinicaDental.Models.Entities
{
    public class Rol
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        // Relación uno a muchos con Usuario (un rol puede estar asociado a varios usuarios)
        public ICollection<Usuario> Usuarios { get; set; }
    }

}
