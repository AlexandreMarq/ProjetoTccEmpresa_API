using Microsoft.EntityFrameworkCore;

namespace ProjetoCoelAPI.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
