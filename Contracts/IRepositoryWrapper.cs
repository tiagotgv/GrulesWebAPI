using Contratos.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contratos
{
    public interface IRepositoryWrapper
    {
        IAluno Aluno { get; }
        IEvento Evento { get; }
        IGrupo Grupo { get; }
        IPresenca Presenca { get; }
        void Save();
    }
}
