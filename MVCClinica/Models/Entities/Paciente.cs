﻿namespace ClinicaSonrrisaPlena.Models.Entities
{
    public class Paciente : Persona
    {
        public Paciente()
        {
            Rol = "Paciente";
        }
        public string RUT { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }

        public ICollection<Turno> Turnos { get; set; } = new List<Turno>();
        public ICollection<HistorialTratamiento> Historiales { get; set; } = new List<HistorialTratamiento>();
        public ICollection<PlanTratamiento> Planes { get; set; } = new List<PlanTratamiento>();

    }
}
