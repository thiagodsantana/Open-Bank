using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OpenBank.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenBank.Repository.Mappings
{
    class ContaMap : IEntityTypeConfiguration<Conta>
    {
        public void Configure(EntityTypeBuilder<Conta> builder)
        {
            // Primary Key
            builder.HasKey(t => t.Id);

            // Table & Column Mappings
            builder.ToTable("TB_CONTAS");
            builder.Property(x => x.Id).HasColumnName("ID_CONTA").IsRequired();
            builder.Property(x => x.ClienteId).HasColumnName("ID_CLIENTE").IsRequired();
            builder.Property(x => x.Agencia).HasColumnName("AGENCIA").IsRequired();
            builder.Property(x => x.NumConta).HasColumnName("CONTA").IsRequired();
            builder.Property(x => x.Saldo).HasColumnName("SALDO").IsRequired();
            builder.Property(x => x.DataCadastro).HasColumnName("DATA_CADASTRO").IsRequired();

            builder.HasOne(x => x.Cliente).WithMany(x => x.Contas);
        }
    }
}
