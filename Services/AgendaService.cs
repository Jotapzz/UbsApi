using UbsApi.Models;

namespace UbsApi.Services
{
    public class AgendaService
    {
        private PacienteService _PacienteService = new PacienteService();
        private MedicoService _MedicoService = new MedicoService();
        private static List<AgendaModel> _AgendaList = new List<AgendaModel>();

        private static int _AgendaID = 1;



        public bool CriarAgendamento(string cpf, string crm, DateTime dataHorarioAgendar, string especialidade)
        {
            if(!_PacienteService.PacienteExiste(cpf))
            {
                return false;
            }
            if (!_MedicoService.ValidarMedico(crm))
            {
                return false;
            }

            //Se o medico não tiver a mesma especialidade que o paciente digitou retorne falso
            if (!string.Equals(_MedicoService.BuscarMedico(crm).Especialidade, especialidade))
            {
                return false;
            }

            if (dataHorarioAgendar < DateTime.Now)
            {
                return false;
            }

            foreach (AgendaModel agenda in _AgendaList)
            {
                if(agenda.DataeHoraAgendamento == dataHorarioAgendar && agenda.CrmMedico == crm)
                {
                    return false;
                }
            }
            
            
            AgendaModel agendamento = new AgendaModel();

            agendamento.AgendaId = _AgendaID;
            _AgendaID ++;
            agendamento.CpfPaciente = cpf;
            agendamento.EspecialidadeMedico = especialidade;
            agendamento.CrmMedico = crm;
            agendamento.DataeHoraAgendamento = dataHorarioAgendar;

            _AgendaList.Add(agendamento);
            return true;
        }
    }
}
