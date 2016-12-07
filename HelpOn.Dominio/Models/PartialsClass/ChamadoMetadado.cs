using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpOn.Dominio.Models
{

    [MetadataType(typeof(ChamadoMetadado))]
    public partial class Chamado
    {

    }
    public  class ChamadoMetadado
    {
        public int IDChamado { get; set; }
        public string Descricao { get; set; }
        public string Processo { get; set; }
        public int NumeroLab { get; set; }
        public int NumeroAndar { get; set; }
        public int IDUnidade { get; set; }
        public Nullable<int> IDFuncionario { get; set; }
        public Nullable<System.DateTime> DataChamado { get; set; }
    }
}
