using System.ComponentModel.DataAnnotations;

namespace BuscaPersonalApi.Entities
{
    public class AcademiaPersonalEntity
    {
        [Key]
        public int Acaper_id { get; set; }
        [Required]
        public int Aca_id { get; set; }
        [Required]
        public int Per_id { get; set; }
        public bool Acaper_ativo { get; set; } = true;
        public DateTime Acaper_data_cadastro { get; set; } = DateTime.Now;
        public AcademiaEntity Academia { get; set; }
        public PersonalEntity Personal { get; set; }
    }
}
