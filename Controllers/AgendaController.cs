using Microsoft.AspNetCore.Mvc;
using UbsApi.Models;
using UbsApi.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UbsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgendaController : ControllerBase
    {
        AgendaService funcaoAgenda = new AgendaService();

        // GET: api/<AgendaController>
        [HttpGet]
        public IActionResult ListarAgendamento()
        {
            List<AgendaModel> agendamentos = funcaoAgenda.ListarAgendamentos();
            return Ok(agendamentos);
            
        }

        // GET api/<AgendaController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AgendaController>
        [HttpPost]
        public IActionResult CriarAgendamento([FromBody] AgendaModel agenda) 
        {
            bool agendamento = funcaoAgenda.CriarAgendamento(
                agenda.CpfPaciente!, 
                agenda.CrmMedico!, 
                agenda.DataeHoraAgendamento, 
                agenda.EspecialidadeMedico!);

            if(agendamento)
            {
                return Created("api/agenda", agenda);
            }

            return BadRequest("Ops.. não foi possível criar seu Agendamento tente novamente!");
        }

        // PUT api/<AgendaController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AgendaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
