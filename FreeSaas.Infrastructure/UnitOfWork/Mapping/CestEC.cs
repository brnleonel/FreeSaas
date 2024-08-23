﻿using FreeSaas.Domain.Entities;
using FreeSaas.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FreeSaas.Infrastructure.UnitOfWork.Mapping
{
    internal class CestEC : DbEntityConfiguration<Cest>
    {
        public override void Configure(EntityTypeBuilder<Cest> entity)
        {
            #region Index, Views, Functions
            #endregion

            #region FK
            #endregion

            #region Columns
            entity.ToTable("Cest",
                t => { t.HasComment("Cest"); }
            );

            entity.HasKey(c => c.Codigo);
            entity.Property(c => c.Codigo)
                .HasColumnType("character varying")
                .HasMaxLength(7)
                .IsRequired();

            entity.Property(c => c.Ncmsh)
                .HasColumnType("character varying")
                .HasMaxLength(8)
                .IsRequired();

            entity.Property(c => c.Descricao)
                .HasColumnType("character varying")
                .HasMaxLength(200)
                .IsRequired();
            #endregion
        }
    }
}
