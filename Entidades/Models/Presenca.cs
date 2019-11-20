using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entidades.Models
{
    [Table("presenca")]
    public class Presenca
    {
        [Key] 
        public int IdPresenca { get; set; }
        
        [Required(ErrorMessage = "Id do aluno é obrigatório")]
        [ForeignKey(nameof(Aluno))]
        public int IdAluno { get; set; }
        public Aluno Aluno { get; set; }

        [Required(ErrorMessage = "Id do evento é obrigatório")]
        [ForeignKey(nameof(Evento))]
        public int IdEvento { get; set; }
        public Evento Evento { get; set; }

        [Required(ErrorMessage = "Data da presença é obrigatória")]
        public DateTime DataInclusao { get; set; }
    }
}
