namespace ClinicaDental.Models.Entities
{
    public class Tratamiento
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string PrecioEstimado { get; set; }

        public List<PasoTratamiento> PasosTratamiento { get; set; } 

    }
}
