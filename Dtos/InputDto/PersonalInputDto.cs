namespace BuscaPersonalApi.Dtos.InputDto
{
    public class PersonalInputDto
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? CPF { get; set; }
        public string? CREF { get; set; }       
        public string? Telefone { get; set; }       
        public DateOnly? DataNascimento { get; set; }
        public string? Especialidade { get; set; }
        public string? Email { get; set; }
        public string? Senha { get; set; }
    }

}
