using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpOn.Dominio.Models
{
    [MetadataType(typeof(NivelMetadado))]
    public partial class Nivel
    {

    }
    public class NivelMetadado
    {
        public int IdNivel { get; set; }
        public string Nome { get; set; }
    }
}
