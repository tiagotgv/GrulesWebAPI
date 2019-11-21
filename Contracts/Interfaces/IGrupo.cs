using Entidades.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contratos.Interfaces
{
    public interface IGrupo
    {
        IEnumerable<Grupo> ListarTodosGrupos();
        Grupo ObterGrupoPorId(int idGrupo);
        void SalvarGrupo(Grupo grupo);
        void ExcluirGrupo(Grupo grupo);
    }
}
