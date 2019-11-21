using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entidades.Models
{
    [Table("eventos")]
    public class Evento
    {
        [Key] 
        public int IdEvento { get; set; }

        [Required(ErrorMessage = "Descrição é obrigatória")]
        [StringLength(200, ErrorMessage = "Descrição não pode ter mais que 200 caracteres")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Data e hora do inclusão são obrigatórios")]
        public DateTime DataInclusao{ get; set; }
        
        [Required(ErrorMessage = "Data e hora do início são obrigatórios")]
        public DateTime DataInicio{ get; set; }

        [Required(ErrorMessage = "Data e hora do término são obrigatórios")]
        public DateTime DataTermino { get; set; }
        
        [ForeignKey(nameof(Grupo.IdGrupo))]
        public List<Grupo> Grupos { get; set; }
    }
}
