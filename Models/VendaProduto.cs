using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EletronicosRuiz.Models
{
    public class VendaProduto
    {
        [Key]
        public int Quantidade { get; set; }

        [ForeignKey("VendaId")]
        public string VendaId { get; set; }

        public Venda? Venda { get; set; }

        [ForeignKey("ProdutoId")]
        public string ProdutoId { get; set; }

        public Produto? Produto { get; set; }
    }
}
