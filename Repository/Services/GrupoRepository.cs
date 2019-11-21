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
    public class GrupoRepository : RepositoryBase<Grupo>, IGrupo
    {
        public GrupoRepository(RepositoryContext repositoryContext) : base(repositoryContext){ }
        public IEnumerable<Grupo> ListarTodosGrupos()
        {
            return FindAll().Include(x => x.Alunos)
                .OrderBy(x => x.Descricao).ToList();
        }
        public Grupo ObterGrupoPorId(int idGrupo)
        {
            return FindByCondition(x => x.IdGrupo.Equals(idGrupo))
                .Include(x => x.Alunos)
                .FirstOrDefault();
        }

        public void SalvarGrupo(Grupo grupo)
        {
            if (grupo.IdGrupo > 0)
            {
                Update(grupo);
            }
            else
            {
                Create(grupo);
            }
        }

        public void ExcluirGrupo(Grupo grupo)
        {
            Delete(grupo);
        }
    }
}
