using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace ProjetoVacina.Models
{
    [Table("IndicacaoIdade")]
    public class IndicacaoIdade
    {
        [Column("IndicacaoIdadeId")]
        [Display(Name = "Código da Indicação de Idade")]
        public int IndicacaoIdadeId { get; set; }

        [Column("IndicacaoIdadeDescricao ")]
        [Display(Name = "Indicação de Idade")]
        public string IndicacaoIdadeDescricao { get; set; } = string.Empty;
    }
}
