namespace BuscaPersonalApi.Dtos.OutputDto
{
    public class PersonalOutputDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CREF { get; set; }
        public string Telefone { get; set; }
        public DateOnly DataNascimento { get; set; }
        public string Especialidade { get; set; }
        public string Email { get; set; }
        public bool Confirmado { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
