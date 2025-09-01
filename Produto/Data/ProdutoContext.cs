using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Produto.Model;

namespace Produto.Data
{
    public class ProdutoContext:DbContext
    {
        public DbSet<ProdutoModel> Produtos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=produtos.sqlite");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
