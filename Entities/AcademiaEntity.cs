using System.ComponentModel.DataAnnotations;

namespace BuscaPersonalApi.Entities
{
    public class AcademiaEntity
    {
        [Key]
        public int Aca_id { get; set; }
        [StringLength(100)]
        public string Aca_nome { get; set; }
        [StringLength(100)]
        public string Aca_cnpj { get; set; }
        [StringLength(100)]
        public string Aca_endereco { get; set; }
        [StringLength(100)]
        public string Aca_bairro { get; set; }
        [StringLength(100)]
        public string Aca_cidade { get; set; }
        [StringLength(100)]
        public string Aca_estado { get; set; }
        [StringLength(100)]
        public string Aca_cep { get; set; }
        [StringLength(100)]
        public string Aca_telefone { get; set; }
        [StringLength(100)]
        public string Aca_email { get; set; }
        [StringLength(100)]
        public string Aca_senha { get; set; }
        public bool Aca_confirmado { get; set; } = false;
        public bool Aca_ativo { get; set; } = true;
        public DateTime Aca_data_cadastro { get; set; } = DateTime.Now;
        public ICollection<AcademiaPersonalEntity> AcademiaPersonal { get; set; }
    }
}
