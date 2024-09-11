using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace ProjetoVacina.Models
{
    [Table("Cadastro")]
    public class Cadastro
    {

        [Column("CadastroId")]
        [Display(Name = "Código do Cadastro")]
        public int CadastroId { get; set; }

        [Column("CadastroCpf")]
        [Display(Name = "Cpf")]
        public int CadastroCpf { get; set; }

        [Column("CadastroEmail")]
        [Display(Name = "Email")]
        public string CadastroEmail { get; set; } = string.Empty;

        [Column("CadastroSenha")]
        [Display(Name = "Senha")]
        public int CadastroSenha { get; set; }

        [Column("CadastroGenero")]
        [Display(Name = "Gênero")]
        public int CadastroGenero { get; set; }

        [Column("CadastroDiaNascimento")]
        [Display(Name = "Dia do Nascimento")]
        public int CadastroDiaNascimento { get; set; }

        [Column("CadastroMesNascimento")]
        [Display(Name = "Mês do Nascimento")]
        public int CadastroMesNascimento { get; set; }

        [Column("CadastroAnoNascimento")]
        [Display(Name = "Ano do Nascimento")]
        public int CadastroAnoNascimento { get; set; }


        [ForeignKey("FrequenciaVacina")]

        public int FrequenciaVacinaId { get; set; }

        public FrequenciaVacina? FrequenciaVacina { get; set; }
    }
}
