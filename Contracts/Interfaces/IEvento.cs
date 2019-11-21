using Entidades.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contratos.Interfaces
{
    public interface IEvento
    {
        IEnumerable<Evento> ListarTodosEventos();
        Evento ObterEventoPorId(int idEvento);
        void SalvarEvento(Evento evento);
        void ExcluirEvento(Evento evento);
    }
}
