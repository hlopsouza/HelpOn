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
        private BancoContext _context = new BancoContext();
        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
            GC.SuppressFinalize(this);
        }




        private IGenericRepository<Funcionario> _FuncionarioRepository;
        public IGenericRepository<Funcionario> FuncionarioRepository
        {
            get
            {
                if (_FuncionarioRepository == null)
                {
                    _FuncionarioRepository = new GenericRepository<Funcionario>(_context);
                }
                return _FuncionarioRepository;
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
