using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestrutura.Data.Configuracao
{
    // Classe que faz o mapeamento da entidade Contato
    // definindo algumas propriedades, como:
    // Id como chave primaria, nome requerido e max de caractere 100...
    public class ContatoConfig : IEntityTypeConfiguration<Contato>
    {
        public void Configure(EntityTypeBuilder<Contato> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Nome).IsRequired().HasMaxLength(100);
            builder.Property(p => p.DataNascimento).HasColumnType("datetime");
            builder.Property(p => p.Sexo);
            builder.Property(p => p.Idade);
            builder.Property(p => p.IsAtivo);
            builder.Property(e => e.CreatedAt).HasColumnType("datetime");
            builder.Property(e => e.UpdatedAt).HasColumnType("datetime");
        }
    }
}
