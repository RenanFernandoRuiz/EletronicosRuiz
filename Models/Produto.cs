using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EletronicosRuiz.Models
{
    public class Produto
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public int QuantidadeEmEstoque { get; set; }

        [ForeignKey("FornecedorId")]
        public long FornecedorId { get; set; }

        public Fornecedor? Fornecedor { get; set; }
    }
}
