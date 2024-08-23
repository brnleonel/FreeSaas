using FreeSaas.Domain.Entities;
using FreeSaas.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FreeSaas.Infrastructure.UnitOfWork.Mapping
{
    internal class IbgeEC : DbEntityConfiguration<Ibge>
    {
        public override void Configure(EntityTypeBuilder<Ibge> entity)
        {
            #region Index, Views, Functions
            #endregion

            #region FK
            #endregion

            #region Columns
            entity.ToTable("Ibge",
                t => { t.HasComment("Ibge"); }
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
