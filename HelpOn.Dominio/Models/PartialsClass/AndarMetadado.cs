using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpOn.Dominio.Models
{
    [MetadataType(typeof(AndarMetadado))]
    public partial class Andar
    {

    }
    public class AndarMetadado
    {
        public int NumeroAndar { get; set; }
        public int IDUnidade { get; set; }
    }
}
