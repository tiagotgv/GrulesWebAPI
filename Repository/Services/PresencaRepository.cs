using Contratos.Interfaces;
using Entidades;
using Entidades.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Services
{
    public class PresencaRepository : RepositoryBase<Presenca>, IPresenca
    {
        public PresencaRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {

        }
    }
}
