using Microsoft.AspNetCore.Mvc;
using UbsApi.Models;
using UbsApi.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UbsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicoController : ControllerBase
    {
        MedicoService MedicoFuncao = new MedicoService();
        // GET: api/<AgendamentoController>
        [HttpGet("listamedicos")]
        public IActionResult GetListarMedico()
        {
            List<MedicoModel> listaMedicoController = MedicoFuncao.ListarMedicos();
            return Ok(listaMedicoController);
        }

        // GET api/<AgendamentoController>/5
        [HttpGet("{crm}")]
        public IActionResult GetMedico(string crm)
        {
            MedicoModel medicoEncontrado = MedicoFuncao.BuscarMedico(crm);

            if(medicoEncontrado != null) //Verifica se o objeto não está vazio
            {
                return Ok(medicoEncontrado);
            }
            return BadRequest();

        }


        // POST api/<AgendamentoController>
        [HttpPost]
        public IActionResult PostMedico([FromBody] MedicoModel medico)
        {
           bool situcao = MedicoFuncao.CadastrarMedico(medico);

            if (situcao)
            {
                return Created("api/Medico", medico);
            }

            return BadRequest("Não é Possivel Cadastrar pois já existe esse médico!");
        }

        
        [HttpPut("{crm}")]
        public IActionResult PutMedico(string crm, [FromBody] MedicoModel medicoAtualizado)
        {
            //Verifica se o Medico foi encontrado (caso seja ele alterar os dados) e armazena o valor True
            bool sucessoMedico = MedicoFuncao.EditarMedico(crm, medicoAtualizado);


            //Caso ele não encontrar aparece um erro
            if(!sucessoMedico)
            {
                return NotFound();
            }

            return Ok();
        }

        // DELETE api/<AgendamentoController>/5
        [HttpDelete("{crm}")]
        public IActionResult DeleteMedico(string crm)
        {
            bool situacaoDeletar = MedicoFuncao.ApagarMedico(crm);

            if(situacaoDeletar)
            {
                return NoContent();
            }

            return BadRequest("CRM não encontrado");
        }
        
    }
}
