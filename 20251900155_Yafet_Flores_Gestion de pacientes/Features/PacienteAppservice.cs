using _20251900155_Yafet_Flores_Gestion_de_pacientes.Models;

namespace _20251900155_Yafet_Flores_Gestion_de_pacientes.Features
{
    public class PacienteAppservice
    {
        private List<Paciente> pacientes = new List<Paciente>();
        private PacienteValidator domain;

        public PacienteAppservice()
        {
            Paciente paciente1 = new Paciente
            {
                Id = 1,
                NombreCompleto = "Juan Perez",
                NumeroIdentidad = "0801199001234",
                FechaNacimiento = new DateTime(1990, 1, 1),
                Telefono = "99991234",
                Activo = true
            };
            pacientes.Add(paciente1);

            Paciente paciente2 = new Paciente
            {
                Id = 2,
                NombreCompleto = "Maria Lopez",
                NumeroIdentidad = "0801199505678",
                FechaNacimiento = new DateTime(1995, 1, 1),
                Telefono = "99992345",
                Activo = true
            };
            pacientes.Add(paciente2);

            Paciente paciente3 = new Paciente
            {
                Id = 3,
                NombreCompleto = "Carlos Rivera",
                NumeroIdentidad = "0801200009876",
                FechaNacimiento = new DateTime(2000, 1, 1),
                Telefono = "99993456",
                Activo = true
            };
            pacientes.Add(paciente3);

            domain = new PacienteValidator();
        }

       
        public List<Paciente> ObtenerPacientes()
        {
            return pacientes;
        }

        
        public Paciente ObtenerPacientePorId(int id)
        {
            return pacientes.Where(x => x.Id == id).First();
        }


        public bool GuardarPacienteConValidacion(Paciente paciente)
        {
            if (!domain.GuardarPaciente(paciente))
                return false;

            // Generar Id automáticamente
            paciente.Id = pacientes.Any() ? pacientes.Max(x => x.Id) + 1 : 1;

            // Agregar a la lista de pacientes
            pacientes.Add(paciente);

            return true;
        }


        public void ActualizarPaciente(Paciente paciente)
        {
            Paciente? pacienteExistente = pacientes.Where(x => x.Id == paciente.Id).FirstOrDefault();

            if (pacienteExistente == null)
            {
                return;
            }

            pacienteExistente.NombreCompleto = paciente.NombreCompleto;
            pacienteExistente.NumeroIdentidad = paciente.NumeroIdentidad;
            pacienteExistente.FechaNacimiento = paciente.FechaNacimiento;
            pacienteExistente.Telefono = paciente.Telefono;
            pacienteExistente.Activo = paciente.Activo;
        }

        
        public void EliminarPaciente(int id)
        {
            pacientes.RemoveAll(x => x.Id == id);
        }


    }
}
