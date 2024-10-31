using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using EletronicosRuiz.Models;

namespace EletronicosRuiz.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<EletronicosRuiz.Models.Cliente> Cliente { get; set; } = default!;
        public DbSet<EletronicosRuiz.Models.Fornecedor> Fornecedor { get; set; } = default!;
        public DbSet<EletronicosRuiz.Models.Produto> Produto { get; set; } = default!;
        public DbSet<EletronicosRuiz.Models.VendaProduto> VendaProduto { get; set; } = default!;
        public DbSet<EletronicosRuiz.Models.Venda> Venda { get; set; } = default!;
    }
}
