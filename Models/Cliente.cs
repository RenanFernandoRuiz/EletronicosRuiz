using System.ComponentModel.DataAnnotations;

namespace EletronicosRuiz.Models
{
    public class Cliente
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Nome { get; set; }

        public string Cpf { get; set; }

        public string Endereco { get; set; }

        public string Telefone { get; set; }

        public string Email { get; set; }
    }
}
