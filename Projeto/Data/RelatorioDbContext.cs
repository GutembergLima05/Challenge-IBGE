using Microsoft.EntityFrameworkCore;
using Projeto.Models;

namespace Projeto.Data
{
    public class RelatorioDbContext : DbContext
    {
        public DbSet<Ibge> IBGE { get; set; }
        public DbSet<Consulta> Consultas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlServer("Server=Zuk;Database=Relatorio;Integrated Security=SSPI;TrustServerCertificate=True");
    }
}