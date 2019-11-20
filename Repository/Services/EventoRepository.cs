using Contratos.Interfaces;
using Entidades;
using Entidades.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Services
{
    public class EventoRepository : RepositoryBase<Evento>, IEvento
    {
        public EventoRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {

        }
    }
}
