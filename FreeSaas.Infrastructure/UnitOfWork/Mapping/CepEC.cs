using FreeSaas.Domain.Entities;
using FreeSaas.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FreeSaas.Infrastructure.UnitOfWork.Mapping
{
    internal class CepEC : DbEntityConfiguration<Cep>
    {
        public override void Configure(EntityTypeBuilder<Cep> entity)
        {
            #region Index, Views, Functions
            #endregion

            #region FK
            #endregion

            #region Columns
            entity.ToTable("Cep",
                t => { t.HasComment("Cep"); }
            );

            entity.HasKey(c => c.Codigo);
            entity.Property(c => c.Codigo)
                .HasColumnType("character varying")
                .HasMaxLength(8)
                .IsRequired();

            entity.Property(c => c.Conteudo)
                .HasColumnType("character varying")
                .HasMaxLength(5000)
                .IsRequired();
            #endregion
        }
    }
}
