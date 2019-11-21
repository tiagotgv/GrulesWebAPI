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
    public class EventoRepository : RepositoryBase<Evento>, IEvento
    {
        public EventoRepository(RepositoryContext repositoryContext) : base(repositoryContext){}

        public void ExcluirEvento(Evento evento)
        {
            Delete(evento);
        }

        public IEnumerable<Evento> ListarTodosEventos()
        {
            return FindAll()
                .Include(x => x.Grupos)
                .OrderBy(x => x.Descricao).ToList();
        }

        public Evento ObterEventoPorId(int idEvento)
        {
            return FindByCondition(x => x.IdEvento.Equals(idEvento))
                .Include(x => x.Grupos)
                .FirstOrDefault();
        }

        public void SalvarEvento(Evento evento)
        {
            if (evento.IdEvento> 0)
            {
                Update(evento);
            }
            else
            {
                Create(evento);
            }
        }
    }
}
