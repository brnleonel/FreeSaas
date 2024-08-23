using FreeSaas.Domain.Entities;
using FreeSaas.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FreeSaas.Infrastructure.UnitOfWork.Mapping
{
    internal class CnaeEC : DbEntityConfiguration<Cnae>
    {
        public override void Configure(EntityTypeBuilder<Cnae> entity)
        {
            #region Index, Views, Functions
            #endregion

            #region FK
            #endregion

            #region Columns
            entity.ToTable("Cnae",
                t => { t.HasComment("Cnae"); }
            );

            entity.HasKey(c => c.Codigo);

            entity.Property(c => c.Descricao)
                .HasColumnType("character varying")
                .HasMaxLength(200)
                .IsRequired();
            #endregion
        }
    }
}
