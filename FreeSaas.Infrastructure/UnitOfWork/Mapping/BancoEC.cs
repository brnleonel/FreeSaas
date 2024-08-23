using FreeSaas.Domain.Entities;
using FreeSaas.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FreeSaas.Infrastructure.UnitOfWork.Mapping
{
    internal class BancoEC : DbEntityConfiguration<Banco>
    {
        public override void Configure(EntityTypeBuilder<Banco> entity)
        {
            #region Index, Views, Functions
            #endregion

            #region FK
            #endregion

            #region Columns
            entity.ToTable("Banco",
                t => { t.HasComment("Febrabran"); }
            );

            entity.HasKey(c => c.Codigo);
            entity.Property(c => c.Codigo)
                .HasColumnType("character varying")
                .HasMaxLength(3)
                .IsRequired();

            entity.Property(c => c.Descricao)
                .HasColumnType("character varying")
                .HasMaxLength(200)
                .IsRequired();

            entity.Property(c => c.Site)
                .HasColumnType("character varying")
                .HasMaxLength(200);
            #endregion
        }
    }
}
