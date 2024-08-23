using FreeSaas.Domain.Entities;
using FreeSaas.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FreeSaas.Infrastructure.UnitOfWork.Mapping
{
    internal class CfopEC : DbEntityConfiguration<Cfop>
    {
        public override void Configure(EntityTypeBuilder<Cfop> entity)
        {
            #region Index, Views, Functions
            #endregion

            #region FK
            #endregion

            #region Columns
            entity.ToTable("Cfop",
                t => { t.HasComment("Cfop"); }
            );

            entity.HasKey(c => c.Codigo);

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
