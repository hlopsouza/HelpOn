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
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public Nullable<System.DateTime> DataCadastro { get; set; }
        public string Nivel { get; set; }
    }
}
