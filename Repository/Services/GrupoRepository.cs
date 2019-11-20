using Contratos.Interfaces;
using Entidades;
using Entidades.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Services
{
    public class GrupoRepository : RepositoryBase<Grupo>, IGrupo
    {
        public GrupoRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {

        }
    }
}
