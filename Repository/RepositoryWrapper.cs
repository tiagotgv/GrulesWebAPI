using Contratos;
using Contratos.Interfaces;
using Entidades;
using Repository.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private RepositoryContext _repoContext;
        private IAluno _aluno;
        private IAlunoGrupo _alunoGrupo;
        private IEvento _evento;
        private IGrupo _grupo;
        private IPresenca _presenca;

        public IAluno Aluno
        {
            get
            {
                if (_aluno == null)
                {
                    _aluno = new AlunoRepository(_repoContext);
                }

                return _aluno;
            }
        }
        public IAlunoGrupo AlunoGrupo
        {
            get
            {
                if (_alunoGrupo == null)
                {
                    _alunoGrupo = new AlunoGrupoRepository(_repoContext);
                }

                return _alunoGrupo;
            }
        }

        public IEvento Evento
        {
            get
            {
                if (_evento == null)
                {
                    _evento = new EventoRepository(_repoContext);
                }

                return _evento;
            }
        }

        public IGrupo Grupo
        {
            get
            {
                if (_grupo == null)
                {
                    _grupo = new GrupoRepository(_repoContext);
                }

                return _grupo;
            }
        }

        public IPresenca Presenca
        {
            get
            {
                if (_presenca == null)
                {
                    _presenca = new PresencaRepository(_repoContext);
                }

                return _presenca;
            }
        }

        public RepositoryWrapper(RepositoryContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }

        public void Save()
        {
            _repoContext.SaveChanges();
        }
    }
}
