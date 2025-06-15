namespace ClinicaSonrrisaPlena.Models.Entities
{
    public class Administrador : Persona
    {
        public Administrador()
        {
            Rol = "Administrador";
        }
        public string RolDescripcion { get; set; }
    }
}
