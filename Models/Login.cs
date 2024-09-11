using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace ProjetoVacina.Models
{
    [Table("Login")]
    public class Login
    {

        [Column("LoginId")]
        [Display(Name = "Código do Login")]
        public int LoginId { get; set; }

        [Column("LoginEmail")]
        [Display(Name = "Email")]
        public string LoginEmail { get; set; } = string.Empty;

        [Column("LoginSenha")]
        [Display(Name = "Senha")]
        public int LoginSenha { get; set; }
    }
}
