using Contratos.Interfaces;
using Entidades;
using Entidades.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Services
{
    public class AlunoRepository : RepositoryBase<Aluno>, IAluno
    {
        public AlunoRepository(RepositoryContext repositoryContext) : base(repositoryContext){}

        public IEnumerable<Aluno> ListarTodosAlunos()
        {
            return FindAll().Include(x => x.Grupo).OrderBy(x => x.Nome).ToList();
        }
        public Aluno ObterAlunoPorId(int idAluno)
        {
            return FindByCondition(x => x.IdAluno.Equals(idAluno))
                .Include(x => x.Grupo)
                .FirstOrDefault();
        } 

        public void SalvarAluno(Aluno aluno)
        {
            if (aluno.IdAluno > 0)
            {
                Update(aluno);
            }
            else
            {
                Create(aluno);
            }
        }
        
        public void ExcluirAluno(Aluno aluno)
        {
            Delete(aluno);
        }
    }
}
