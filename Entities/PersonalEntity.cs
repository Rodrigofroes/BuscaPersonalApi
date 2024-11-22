using System.ComponentModel.DataAnnotations;

namespace BuscaPersonalApi.Entities
{
    public class PersonalEntity
    {
        [Key]
        public int Per_id { get; set; }
        [StringLength(100)]
        public string Per_nome { get; set; }
        [StringLength(100)]
        public string Per_cpf { get; set; }
        [StringLength(100)]
        public string Per_cref { get; set; }
        [StringLength(100)]
        public string Per_telefone { get; set; }
        [StringLength(100)]
        public string Per_especialidades { get; set; }
        [StringLength(100)]
        public string Per_email { get; set; }
        [StringLength(100)]
        public string Per_senha { get; set; }
        public bool Per_confirmado { get; set; } = false;
        public bool Per_ativo { get; set; } = true;
        public DateTime Per_data_cadastro { get; set; } = DateTime.Now;
        public DateOnly Per_data_nascimento { get; set; } 
        public ICollection<AcademiaPersonalEntity> AcademiaPersonal { get; set; }
    }
}
