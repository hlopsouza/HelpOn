using HelpOn.Dominio.Models;
using HelpOn.Persistencia.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpOn.Persistencia.UnitOfWork
{
    public class UnitOfWork : IDisposable
    {
        private HelpOnEntities _context = new HelpOnEntities();
        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
            GC.SuppressFinalize(this);
        }




        private IGenericRepository<Gerente> _gerenteRepository;
        public IGenericRepository<Gerente> GerenteRepository
        {
            get
            {
                if (_gerenteRepository == null)
                {
                    _gerenteRepository = new GenericRepository<Gerente>(_context);
                }
                return _gerenteRepository;
            }
        }

        private IGenericRepository<Laboratorio> _laboratorioRepository { get; set; }
        public IGenericRepository<Laboratorio> LaboratorioRepository
        {
            get
            {
                if (_laboratorioRepository == null)
                {
                    _laboratorioRepository = new GenericRepository<Laboratorio>(_context);
                }
                return _laboratorioRepository;
            }
        }

        private IGenericRepository<Andar> _andarRepository { get; set; }
        public IGenericRepository<Andar> AndarRepository
        {
            get
            {
                if (_andarRepository == null)
                {
                    _andarRepository = new GenericRepository<Andar>(_context);
                }
                return _andarRepository;
            }
        }

        private IGenericRepository<Unidade> _unidadeRepository;
        public IGenericRepository<Unidade> UnidadeRepository
        {
            get
            {
                if (_unidadeRepository == null)
                {
                    _unidadeRepository = new GenericRepository<Unidade>(_context);
                }
                return _unidadeRepository;
            }
        }

        private IChamadoRepository _chamadoRepository;
        public IChamadoRepository ChamadoRepository
        {
            get
            {
                if (_chamadoRepository == null)
                {
                    _chamadoRepository = new ChamadoRepository(_context);
                }
                return _chamadoRepository;
            }
        }

        public void Salvar()
        {
            _context.SaveChanges();
        }

    }
}
