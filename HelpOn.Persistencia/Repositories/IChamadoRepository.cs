using HelpOn.Dominio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpOn.Persistencia.Repositories
{
    public interface IChamadoRepository:IGenericRepository<Chamado>
    {
        ICollection<Chamado> BuscarChamadosAbertos(int nivelFuncionario);
       
    }
}
