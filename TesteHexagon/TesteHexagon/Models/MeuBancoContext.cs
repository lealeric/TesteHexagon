using Microsoft.EntityFrameworkCore;

namespace TesteHexagon.Models
{
    public class MeuBancoContext : DbContext
    {
        public MeuBancoContext(DbContextOptions<MeuBancoContext> options) : base(options)
        {
        }
        public DbSet<Pessoa> Pessoas { get; set; }
    }
}
