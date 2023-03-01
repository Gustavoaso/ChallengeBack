using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaDeCadastro.Models;

namespace SistemaDeCadastro.Data.Map
{
    public class ProjetoMap : IEntityTypeConfiguration<ProjetoModel>
    {
        public void Configure(EntityTypeBuilder<ProjetoModel> builder)
    {
        builder.HasKey(x => x.IdProjeto);
        builder.Property(x => x.NomeProjeto).IsRequired();
        builder.Property(x => x.DataCriacao).IsRequired();
        builder.Property(x => x.DataTermino).IsRequired();
            builder.Property(x => x.Gerente).IsRequired();
    }
}
    
}
