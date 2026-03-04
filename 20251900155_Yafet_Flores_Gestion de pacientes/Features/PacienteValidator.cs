using _20251900155_Yafet_Flores_Gestion_de_pacientes.Models;

namespace _20251900155_Yafet_Flores_Gestion_de_pacientes.Features
{
    public class PacienteValidator
    {
        public bool GuardarPaciente(Paciente paciente)
        {
            // Nombre completo no puede estar vacío
            if (string.IsNullOrWhiteSpace(paciente.NombreCompleto))
            {
                return false;
            }

            // Numero de identidad no puede estar vacío y debe tener 13 caracteres
            if (string.IsNullOrWhiteSpace(paciente.NumeroIdentidad) || paciente.NumeroIdentidad.Length != 13)
            {
                return false;
            }

            // Teléfono no puede estar vacío y mínimo 8 dígitos
            if (string.IsNullOrWhiteSpace(paciente.Telefono) || paciente.Telefono.Length < 8)
            {
                return false;
            }

            // Fecha de nacimiento no puede ser mayor a la fecha actual
            if (paciente.FechaNacimiento > DateTime.Now)
            {
                return false;
            }

            return true;
        }

    }
}
