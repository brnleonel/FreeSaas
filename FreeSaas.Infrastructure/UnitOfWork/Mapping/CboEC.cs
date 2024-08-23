using FreeSaas.Domain.Entities;
using FreeSaas.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FreeSaas.Infrastructure.UnitOfWork.Mapping
{
    internal class CboEC : DbEntityConfiguration<Cbo>
    {
        public override void Configure(EntityTypeBuilder<Cbo> entity)
        {
            #region Index, Views, Functions
            #endregion

            #region FK
            #endregion

            #region Columns
            entity.ToTable("Cbo",
                t => { t.HasComment("Cadastro Brasileiro de Ocupação"); }
            );

            entity.HasKey(c => c.Codigo);
            entity.Property(c => c.Codigo)
                .HasColumnType("character varying")
                .HasMaxLength(6)
                .IsRequired();

            entity.Property(c => c.Descricao)
                .HasColumnType("character varying")
                .HasMaxLength(200)
                .IsRequired();

            entity.Property(c => c.Aplicacao)
                .HasColumnType("character varying")
                .HasMaxLength(200);
            #endregion
        }
    }
}
