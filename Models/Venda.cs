using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EletronicosRuiz.Models
{
    public class Venda
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        public DateTime DataEmissao { get; set; }
        public decimal ValorTotal { get; set; }

        [ForeignKey("ClienteId")]
        public string ClienteId { get; set; }
        public Cliente? Cliente { get; set; }

        public List<VendaProduto>? VendaProdutos { get; set; }

    }
}
