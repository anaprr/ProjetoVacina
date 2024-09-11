using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace ProjetoVacina.Models
{
    [Table("FrequenciaVacina")]
    public class FrequenciaVacina
    {
        [Column("FrequenciaVacinaId")]
        [Display(Name = "Código da Frequência da Vacina")]
        public int FrequenciaVacinaId { get; set; }

        [Column("FrequenciaVacinaDescricao ")]
        [Display(Name = "Frequência da Vacina")]
        public string FrequenciaVacinaDescricao { get; set; } = string.Empty;

    }
}
