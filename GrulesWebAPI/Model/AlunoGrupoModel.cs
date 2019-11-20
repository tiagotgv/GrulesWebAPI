using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrulesWebAPI.Model
{
    public class AlunoGrupoModel
    {
        public int IdAluno { get; set; }
        public AlunoModel Aluno { get; set; }
        public int IdGrupo { get; set; }
        public GrupoModel Grupo { get; set; }
    }
}
