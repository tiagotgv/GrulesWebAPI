using Contratos.Interfaces;
using Entidades;
using Entidades.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Services
{
    public class AlunoGrupoRepository : RepositoryBase<AlunoGrupo>, IAlunoGrupo
    {
        public AlunoGrupoRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {

        }
    }
}
