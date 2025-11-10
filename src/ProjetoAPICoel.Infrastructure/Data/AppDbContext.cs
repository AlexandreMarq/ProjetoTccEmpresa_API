using Microsoft.EntityFrameworkCore;
using ProjetoAPICoel.Domain.Entities;

namespace ProjetoAPICoel.Infrastructure.Data
{

    public class AppDbContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProdutoDto>().HasNoKey();
        }
        public DbSet<ProdutoDto> Produtos { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }

}
