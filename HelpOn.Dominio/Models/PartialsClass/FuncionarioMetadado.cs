using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpOn.Dominio.Models
{

    [MetadataType(typeof(FuncionarioMetadado))]
    public partial class Funcionario
    {

    }
    public class FuncionarioMetadado
    {


        public int IDFuncionario { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string CPF { get; set; }
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        [Required]
        [StringLength(10, MinimumLength = 6, ErrorMessage = "Senha deve conter entre 6 e 10 caracteres")]
        public string Senha { get; set; }
        public Nullable<System.DateTime> DataCadastro { get; set; }
        [Required]
        public int IDNivel { get; set; }

        public virtual Nivel Nivel { get; set; }
    }
}
