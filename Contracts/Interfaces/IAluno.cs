using Entidades.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contratos.Interfaces
{
    public interface IAluno
    {
        IEnumerable<Aluno> ListarTodosAlunos();
        Aluno ObterAlunoPorId(int idAluno);
        void SalvarAluno(Aluno aluno);
        void ExcluirAluno(Aluno aluno);
    }
}
