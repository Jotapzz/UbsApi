using System.ComponentModel.DataAnnotations;

namespace UbsApi.Models
{
    public class PacienteModel
    {
        [Required]
        public string? Cpf { get; set; }
        public string? Nome { get; set; }
        public string? Telefone { get; set; }
        public DateTime DataNascimento { get; set; }
        public string? Endereco { get; set; }
        public string? NomeAgenteSaude { get; set; }
        public string? CpfResponsavel { get; set; }

    }
}
