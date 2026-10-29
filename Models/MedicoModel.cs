using System.ComponentModel.DataAnnotations;

namespace UbsApi.Models
{
    public class MedicoModel
    {
        [Required]
        public string? Crm {  get; set; }
        public string? Nome { get; set;  }
        public string? Telefone { get; set; }
        public string? Especialidade { get; set; }

    }
}
