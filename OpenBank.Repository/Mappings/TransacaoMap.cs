using Microsoft.EntityFrameworkCore;
using OpenBank.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenBank.Repository.Mappings
{
    class TransacaoMap : IEntityTypeConfiguration<Transacao>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Transacao> builder)
        {
            // Primary Key
            builder.HasKey(t => t.Id);

            // Table & Column Mappings
            builder.ToTable("TB_TRANSACOES");
            builder.Property(x => x.Id).HasColumnName("ID_TRANSACAO").IsRequired();
            builder.Property(x => x.ContaId).HasColumnName("ID_CONTA").IsRequired();
            builder.Property(x => x.TipoMovimento).HasColumnName("TIPO_MOVIMENTO").IsRequired();
            builder.Property(x => x.valor).HasColumnName("VALOR").IsRequired();
            builder.Property(x => x.DataHora).HasColumnName("DATA_HORA").IsRequired();

            builder.HasOne(x => x.Conta).WithMany(x => x.Transacoes);
        }
    }
}
