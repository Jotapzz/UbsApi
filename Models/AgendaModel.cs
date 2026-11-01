using System.ComponentModel.DataAnnotations;

namespace UbsApi.Models
{
    public class AgendaModel
    {
        [Required]
        public int AgendaId { get; set; } = 0;
        public string? CpfPaciente { get; set; }
        public string? CrmMedico { get; set; }
        public string? EspecialidadeMedico { get; set; }
        public DateTime DataeHoraAgendamento { get; set; }
    }
}
