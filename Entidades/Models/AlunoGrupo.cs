using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entidades.Models
{
    [Table("alunos_grupo")]
    public class AlunoGrupo
    {
        [Key]
        public int IdAlunoGrupo { get; set; }
        
        [Required(ErrorMessage = "Id do aluno é obrigatório")]
        [ForeignKey(nameof(Aluno))]
        public int IdAluno { get; set; }
        public Aluno Aluno { get; set; }

        [Required(ErrorMessage = "Id do grupo é obrigatório")]
        [ForeignKey(nameof(Grupo))]
        public int IdGrupo { get; set; }
        public Grupo Grupo { get; set; }

    }
}
