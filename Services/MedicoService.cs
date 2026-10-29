using UbsApi.Models;

namespace UbsApi.Services
{
    public class MedicoService
    {





        private static List<MedicoModel> _ListaMedicos = new List<MedicoModel>
        {
            new MedicoModel {Crm = "2101PE", Nome = "Dra. Ana", Telefone = "81977742345", Especialidade = "Clínica Geral"},
            new MedicoModel {Crm = "2304PE", Nome = "Dr. João", Telefone = "81995603182", Especialidade = "Cardiologista"},

        };


        //Validação se o CRM do Médico Existe

        public bool ValidarMedico(string crm)
        {
            foreach (MedicoModel medico in _ListaMedicos)
            {
                if (medico.Crm == crm)
                {
                    return true;
                }
            }

            return false;
        }



        //Cadastrar Médico
        public bool CadastrarMedico(MedicoModel medicoNovo)
        {

            if (medicoNovo.Crm.Length < 6 || medicoNovo.Nome.Length < 3)
            {
                return false;
            }

            _ListaMedicos.Add(medicoNovo);

            //Retorna os dados do médico cadastrado
            return true;



        }

        //Editar Médico

        public bool EditarMedico(string crmEditar, MedicoModel medicoEditar)
        {
            foreach (MedicoModel medico in _ListaMedicos)
            {
                if (medico.Crm == crmEditar)
                {
                    medico.Crm = medicoEditar.Crm;
                    medico.Nome = medicoEditar.Nome;
                    medico.Telefone = medicoEditar.Telefone;
                    medico.Especialidade = medicoEditar.Especialidade;
                    return true;
                }
            }

            return false;
        }

        //Excluir Médico
        public bool ApagarMedico(string crm)
        {
            foreach (MedicoModel medico in _ListaMedicos)
            {
                if (medico.Crm == crm)
                {
                    _ListaMedicos.Remove(medico);
                    return true;
                }
            }
            return false;
        }

        //Listar Médico
        public List<MedicoModel> ListarMedicos()
        {
            return _ListaMedicos;
        }


        //Buscar Médico
        public MedicoModel BuscarMedico(string crm)
        {
            MedicoModel medicoNaoEncontrado = new MedicoModel();
            foreach (MedicoModel medico in _ListaMedicos)
            {
                if(medico.Crm == crm)
                {
                    return medico;
                }
            }

            return medicoNaoEncontrado;
        }
    }
}
