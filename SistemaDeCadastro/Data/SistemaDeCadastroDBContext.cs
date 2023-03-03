using Microsoft.EntityFrameworkCore;
using SistemaDeCadastro.Data.Map;
using SistemaDeCadastro.Models;


namespace SistemaDeCadastro.Data
{
    public class SistemaDeCadastroDBContext : DbContext
    {
        public SistemaDeCadastroDBContext(DbContextOptions<SistemaDeCadastroDBContext> options) : base(options) 
        { 
        } 
        public DbSet<EmpregadoModel> empregados { get; set; }
        public DbSet<ProjetoModel> projetos { get; set; }
      
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EmpregadoMap());
            modelBuilder.ApplyConfiguration(new ProjetoMap());
          
            base.OnModelCreating(modelBuilder); 
        }
    } 
}
