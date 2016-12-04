using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpOn.Dominio.Model
{

    [MetadataType(typeof(UnidadeMetadado))]
    public partial class Unidade
    {

    }
    public class UnidadeMetadado
    {
        public int IDUnidade { get; set; }
        public string Nome { get; set; }
        public string CEP { get; set; }
        public string Logradouro { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }

    }
}
