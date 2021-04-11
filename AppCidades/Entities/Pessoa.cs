using System.ComponentModel.DataAnnotations;

namespace AppCidades.Entities
{
    public class Pessoa
    {
        [Key]
        public long id { get; set; }

        [Required]
        public string nome { get; set; }
        public string sexo { get; set; }
        public string cpf { get; set; }
        public string email { get; set; }
        
    }
}
