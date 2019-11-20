using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrulesWebAPI.Model
{
    public class EventoModel
    {
        public int IdEvento { get; set; }
        public string Descricao { get; set; }
        public DateTime DataInclusao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataTermino { get; set; }
    }
}
