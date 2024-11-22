using BuscaPersonalApi.Entities;
using System.ComponentModel.DataAnnotations;

namespace BuscaPersonalApi.Dtos.InputDto
{
    public class PersonalInputDto
    {
        [Required(ErrorMessage = "O campo Id é obrigatório.")]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O campo CPF é obrigatório.")]
        public string CPF { get; set; }
        [Required(ErrorMessage = "O campo CREF é obrigatório.")]
        public string CREF { get; set; }
        [Required(ErrorMessage = "O campo Telefone é obrigatório.")]
        public string Telefone { get; set; }
        [Required(ErrorMessage = "O campo Data de Nascimento é obrigatório.")]
        public DateOnly DataNascimento { get; set; }
        [Required(ErrorMessage = "O campo Especialidade é obrigatório.")]
        public string Especialidade { get; set; }
        [Required(ErrorMessage = "O campo Email é obrigatório.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "O campo Senha é obrigatório.")]
        public string Senha { get; set; }
    }

}
