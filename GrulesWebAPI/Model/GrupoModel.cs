using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GrulesWebAPI.Model
{
    public class GrupoModel
    {
        public int? IdGrupo { get; set; }

        [Required(ErrorMessage = "Título é obrigatório")]
        [StringLength(100, ErrorMessage = "Título não pode ter mais que 100 caracteres")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "Descrição é obrigatória")]
        [StringLength(250, ErrorMessage = "Descrição não pode ter mais que 250 caracteres")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "IdEvento é obrigatório")]
        [Range(1, Double.PositiveInfinity, ErrorMessage = "IdEvento deve ser maior que 0")]
        public int IdEvento { get; set; }
        public List<AlunoModel> Alunos { get; set; }
    }
}
