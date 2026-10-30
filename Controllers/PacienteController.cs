using Microsoft.AspNetCore.Mvc;
using UbsApi.Models;
using UbsApi.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UbsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        PacienteService pacienteFuncao = new PacienteService();


        // GET: api/<PacienteController>
        [HttpGet]
        public IActionResult GetListarPacientes()
        {
            List<PacienteModel> listaPaciente = pacienteFuncao.ListarPacientes();

            return Ok(listaPaciente);
        }

        // GET api/<PacienteController>/5
        [HttpGet("{cpf}")]
        public IActionResult Get(string cpf)
        {
            PacienteModel buscarPaciente = pacienteFuncao.BuscarPaciente(cpf);

            if(buscarPaciente != null)
            {
                return Ok(buscarPaciente);
            }
           
            return BadRequest();
        }

        // POST api/<PacienteController>
        [HttpPost]
        public IActionResult PostPaciente([FromBody] PacienteModel paciente)
        {
            bool statusCadastral = pacienteFuncao.CadastrarPaciente(paciente);

            if(statusCadastral)
            {
                return Created("api/paciente", paciente);
            }

            return BadRequest("Ops.. não foi possível Cadastrar o Paciente!");
        }

        // PUT api/<PacienteController>/5
        [HttpPut("{cpf}")]
        public IActionResult PutPaciente(string cpf, [FromBody] PacienteModel paciente)
        {
            bool statusEdicao = pacienteFuncao.EditarPaciente(cpf, paciente);

            if(!statusEdicao)
            {
                return NotFound("Ops... não foi possivel editar o dados do Paciente, verifique o cpf!");
            }

            return Ok("Edição do Paciente realizada com Sucesso!");
        }

        // DELETE api/<PacienteController>/5
        [HttpDelete("{cpf}")]
        public IActionResult DeletePaciente(string cpf)
        {
            bool statusExcluir = pacienteFuncao.ExcluirPaciente(cpf);
            
            if(statusExcluir)
            {
                return NoContent();
            }

            return BadRequest("Cpf do Paciente não Encontrado!");
        }
    }
}
