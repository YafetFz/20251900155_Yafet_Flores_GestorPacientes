using Microsoft.AspNetCore.Mvc;
using _20251900155_Yafet_Flores_Gestion_de_pacientes.Models;
using _20251900155_Yafet_Flores_Gestion_de_pacientes.Features;

namespace _20251900155_Yafet_Flores_Gestion_de_pacientes.Controllers
{
    [Route("api/PacientesController")]
    [ApiController]

    public class PacientesController : ControllerBase
    {
        private readonly PacienteAppservice pacienteAppService;

        public PacientesController(PacienteAppservice pacienteAppService)
        {
            this.pacienteAppService = pacienteAppService;
        }

        // Endpoint para listar todos los pacientes
        [HttpGet("ListarPacientes")]
        public IActionResult ObtenerPacientes()
        {
            List<Paciente> pacientes = pacienteAppService.ObtenerPacientes();
            return Ok(pacientes);
        }

        // Endpoint para obtener un paciente por su Id
        [HttpGet]
        [Route("ObtenerPacientePorId/{id}")]
        public IActionResult ObtenerPacientePorId([FromRoute] int id)
        {
            return Ok(pacienteAppService.ObtenerPacientePorId(id));
        }

        // Endpoint para agregar un nuevo paciente
        [HttpPost]
        [Route("AgregarPaciente")]
        public IActionResult GuardarPaciente([FromBody] Paciente paciente)
        {
            if (!pacienteAppService.GuardarPacienteConValidacion(paciente))
            {
                return BadRequest("Paciente no cumple las validaciones de negocio");
            }

            return Ok("Paciente agregado exitosamente");
        }

        // Endpoint para actualizar un paciente existente
        [HttpPut]
        [Route("ActualizarPaciente")]
        public IActionResult ActualizarPaciente([FromBody] Paciente paciente)
        {
            pacienteAppService.ActualizarPaciente(paciente);
            return Ok("Paciente actualizado exitosamente");
        }

        // Endpoint para borrar un paciente existente
        [HttpDelete]
        [Route("EliminarPaciente/{id}")]
        public IActionResult EliminarPaciente([FromRoute] int id)
        {
            pacienteAppService.EliminarPaciente(id);
            return Ok("Paciente eliminado exitosamente");
        }
    }
}
