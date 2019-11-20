using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrulesWebAPI.Model
{
    public class GrupoModel
    {
        public int IdGrupo { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public EventoModel Evento { get; set; }
    }
}
