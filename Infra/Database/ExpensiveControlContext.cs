using DespesasControlApp.Models.Despesass;
using Microsoft.EntityFrameworkCore;

namespace DespesasControlApp.Infra.Database
{
    public class DespesasControlContext : DbContext
    {
        public DbSet<Despesas> Despesass { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=51.81.55.67;Database=ProjetoMVC;User=sa;Password=ContaCerta1@@;");
        }
    }
}
