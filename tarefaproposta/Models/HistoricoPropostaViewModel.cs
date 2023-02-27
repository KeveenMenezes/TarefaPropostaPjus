using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace tarefaproposta.Models
{
    public class HistoricoPropostaViewModel
    {
        public string ValorPropostaString { get; set; }
        public DateTime DataEnvio { get; set; }
        public Canal Canal { get; set; }  
        public Destinado Destinado { get; set; }
    }

    public enum Canal
    {
        [Display(Name = "Whatsapp")]
        Whatsapp = 0,
        [Display(Name = "Email")]
        Email = 1,
        [Display(Name = "Ligação")]
        Ligacao = 2
    }

    public enum Destinado
    {
        [Display(Name = "Credor")]
        Credor = 0,
        [Display(Name = "Advogado")]
        Advogado = 1,
        [Display(Name = "Parceiro")]
        Parceiro = 2
    }
}
