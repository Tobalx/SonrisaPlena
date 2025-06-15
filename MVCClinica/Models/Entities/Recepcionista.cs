namespace ClinicaSonrrisaPlena.Models.Entities
{
    public class Recepcionista : Persona
    {
        public Recepcionista()
        {
            Rol = "Recepcionista";
        }
        public string Interno { get; set; }
    }
}
