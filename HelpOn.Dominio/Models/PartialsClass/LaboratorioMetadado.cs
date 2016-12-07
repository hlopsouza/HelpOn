using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpOn.Dominio.Models
{
    [MetadataType(typeof(LaboratorioMetadado))]
    public partial class Laboratorio
    {

    }
    public class LaboratorioMetadado
    {
        public int NumeroLab { get; set; }
        public int NumeroAndar { get; set; }
        public int IDUnidade { get; set; }
    }
}
