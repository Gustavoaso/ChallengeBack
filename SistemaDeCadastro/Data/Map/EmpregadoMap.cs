using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaDeCadastro.Models;

namespace SistemaDeCadastro.Data.Map
{
    public class EmpregadoMap : IEntityTypeConfiguration<EmpregadoModel>
    {
        public void Configure(EntityTypeBuilder<EmpregadoModel> builder)
        {
            builder.HasKey(x => x.IdEmpregado);
            builder.Property(x => x.PrimeiroNome).IsRequired();
            builder.Property(x => x.UltimoNome).IsRequired();
            builder.Property(x => x.Endereco).IsRequired();
            builder.Property(x => x.Telefone).IsRequired().HasMaxLength(10);
        }
    }
}
