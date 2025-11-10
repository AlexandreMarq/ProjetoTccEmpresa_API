using Microsoft.EntityFrameworkCore;
using ProjetoCoelAPI.Domain.Entities;

namespace ProjetoCoelAPI.Infrastructure.Data
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
