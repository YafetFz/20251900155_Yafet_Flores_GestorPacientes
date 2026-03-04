namespace _20251900155_Yafet_Flores_Gestion_de_pacientes.Models
{
    public class Paciente
    {
        public int Id { get; set; }

        public string NombreCompleto { get; set; }

        public string NumeroIdentidad { get; set; } 

        public DateTime FechaNacimiento { get; set; }

        public string Telefono { get; set; }

        public bool Activo { get; set; }
    }
}
