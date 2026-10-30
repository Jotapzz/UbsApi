using UbsApi.Models;

namespace UbsApi.Services
{
    public class PacienteService
    {
        public static List<PacienteModel> _ListaPacientes = new List<PacienteModel>
        {
            new PacienteModel {Cpf = "12345678901", Nome = "João da Silva", Telefone = "81999999999", DataNascimento = new DateTime(1990, 1, 1), Endereco = "Rua A, 123", NomeAgenteSaude = "Maria Souza", CpfResponsavel = "98765432100"},
            new PacienteModel {Cpf = "98765432100", Nome = "Maria Souza", Telefone = "81988888888", DataNascimento = new DateTime(1985, 5, 15), Endereco = "Rua B, 456", NomeAgenteSaude = "João da Silva", CpfResponsavel = "12345678901"}
        };



        public bool VerificarMaioridade(DateTime data)
        {
            if(data.AddYears(18) < DateTime.Now)
            {
                return false;
            }

            return true;
        }

        //Verifica o cpf do paciente
        public bool ValidarCpf(string cpf)
        {
            if(cpf.Length < 11 || string.IsNullOrEmpty(cpf))
            {
                return false;
            }

            return true;
        }

        //Lista Todos os Pacientes
        public List<PacienteModel> ListarPacientes()
        {
            return _ListaPacientes;
        }

        //Busca o paciente pelo CPF
        public PacienteModel BuscarPaciente(string cpf)
        {
            PacienteModel pacienteNaoEncontrado = new PacienteModel();
            foreach (PacienteModel paciente in _ListaPacientes)
            {
                if (paciente.Cpf == cpf)
                {
                    return paciente;
                }
            }
            return pacienteNaoEncontrado;
        }

        //Cadastra o Paciente com as verificação
        public bool CadastrarPaciente (PacienteModel paciente)
        {

            //validar cpf
            if(!ValidarCpf(paciente.Cpf!))
            {
                return false;
            }
            // paciente existe
            if (PacienteExiste(paciente.Cpf!))
            {
                return false;
            } else
            {
                if(!VerificarMaioridade(paciente.DataNascimento))
                {
                    if(!ValidarCpf(paciente.CpfResponsavel!))
                    {
                        return false;
                    }
                }
            }

            _ListaPacientes.Add(paciente);
            return true;

        }

        //função p verificar se o cpf existe
        public bool PacienteExiste(string cpf)
        {
            foreach (PacienteModel paciente in _ListaPacientes)
            {
                if (paciente.Cpf == cpf)
                {
                    return true;
                }
            }

            return false;
        }


        //Verifica se existe um cpf de maior, caso exista ele edita o paciente
        public bool EditarPaciente (string cpf, PacienteModel pacienteEditado)
        {
            foreach (PacienteModel paciente in _ListaPacientes)
            {
                if(paciente.Cpf == cpf)
                {

                }
            }

            return false;
        }

        //Exclui um Paciente de acordo com o cpf Digitado
        public bool ExcluirPaciente (string cpf)
        {
            foreach (PacienteModel paciente in _ListaPacientes)
            {
                if(paciente.Cpf == cpf )
                {
                    _ListaPacientes.Remove(paciente);
                    return true;
                }
            }

            return false;
        }

        
    }
}
