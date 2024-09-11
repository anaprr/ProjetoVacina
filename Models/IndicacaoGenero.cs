using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace ProjetoVacina.Models
{
    [Table("IndicacaoGenero")]
    public class IndicacaoGenero
    {
        [Column("IndicacaoGeneroId")]
        [Display(Name = "Código da Indicação de Gênero")]
        public int IndicacaoGeneroId { get; set; }

        [Column("IndicacaoGeneroDescricao ")]
        [Display(Name = "Indicação de Genero")]
        public string IndicacaoGeneroDescricao { get; set; } = string.Empty;
    }
}
