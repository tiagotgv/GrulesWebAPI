using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GrulesWebAPI.Model
{
    public class AlunoModel
    {
        public int IdAluno { get; set; }
        [Required(ErrorMessage = "Nome é obrigatório")]
        [StringLength(100, ErrorMessage = "Nome não pode ter mais que 100 caracteres")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Sobrenome é obrigatório")]
        [StringLength(100, ErrorMessage = "Sobrenome não pode ter mais que 100 caracteres")]
        public string Sobrenome { get; set; }
        [Required(ErrorMessage = "CPF é obrigatório")]
        [StringLength(14, ErrorMessage = "CPF não pode ter mais que 14 caracteres")]
        public string CPF { get; set; }
        [Required(ErrorMessage = "Matrícula é obrigatório")]
        [StringLength(20, ErrorMessage = "Matrícula não pode ter mais que 20 caracteres")]
        public string Matricula { get; set; }
        public string Celular { get; set; }
        [Required(ErrorMessage = "Email é obrigatório")]
        [StringLength(200, ErrorMessage = "Email não pode ter mais que 200   caracteres")]
        public string Email { get; set; }
        public string Endereco { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string CEP { get; set; }
        public string Observacoes { get; set; }
        public GrupoModel Grupo { get; set; }
    }
}
