using HelpOn.Dominio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpOn.Persistencia.Repositories
{
   public class ChamadoRepository : GenericRepository<Chamado>, IChamadoRepository
    {
        public ChamadoRepository(BancoContext context) : base(context)
        {
        }

       
        public ICollection<Chamado> BuscarChamadosAbertos(int nivelFuncionario)
        {
            if (nivelFuncionario != 1)
            {
                return _dbSet.Where(c => c.Processo == "Aberto").ToList();
            }
            return _dbSet.Where(c => c.Processo == "Aberto" && c.IDNivel == nivelFuncionario).ToList();
        }
    }
}
