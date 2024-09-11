using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace ProjetoVacina.Models
{
    [Table("Vacina")]
    public class Vacina
    {
        [Column("VacinaId")]
        [Display(Name = "Código da Vacina")]
        public int VacinaId { get; set; }

        [Column("VacinaNome")]
        [Display(Name = "Nome da Vacina")]
        public string VacinaNome { get; set; } = string.Empty;

        [Column("VacinaDescricao")]
        [Display(Name = "Descrição da Vacina")]
        public string VacinaDescricao { get; set; } = string.Empty;

        [ForeignKey("IndicacaoGenero")]
        public int IndicacaoGeneroId { get; set; }
        public IndicacaoGenero? IndicacaoGenero { get; set; }

        [ForeignKey("IndicacaoIdade")]
        public int IndicacaoIdadeId { get; set; }
        public IndicacaoIdade? IndicacaoIdade { get; set; }


    }
}
