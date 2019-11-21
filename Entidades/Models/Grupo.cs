using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entidades.Models
{
    [Table("grupos")]
    public class Grupo
    {
        [Key] 
        public int IdGrupo { get; set; }

        [Required(ErrorMessage = "Título é obrigatório")]
        [StringLength(100, ErrorMessage = "Título não pode ter mais que 100 caracteres")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "Descrição é obrigatória")]
        [StringLength(250, ErrorMessage = "Descrição não pode ter mais que 250 caracteres")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Id do evento é obrigatório")]
        [ForeignKey(nameof(Evento))]
        public int IdEvento { get; set; }
        public Evento Evento { get; set; }
        
        [ForeignKey(nameof(Aluno.IdAluno))]
        public List<Aluno> Alunos { get; set; }

    }
}
