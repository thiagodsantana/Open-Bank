﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OpenBank.Domain.Models;

namespace OpenBank.Repository.Mappings
{
    class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            // Primary Key
            builder.HasKey(t => t.Id);

            // Table & Column Mappings
            builder.ToTable("TB_CLIENTES");
            builder.Property(x => x.Id).HasColumnName("ID_CLIENTE").IsRequired();
            builder.Property(x => x.Cpf).HasColumnName("CPF").IsRequired().HasMaxLength(11);
            builder.Property(x => x.Nome).HasColumnName("NOME").IsRequired().HasMaxLength(100);
            builder.Property(x => x.SobreNome).HasColumnName("SOBRENOME").IsRequired().HasMaxLength(150);
            builder.Property(x => x.Senha).HasColumnName("SENHA").IsRequired().HasMaxLength(50);
            builder.Property(x => x.DataCadastro).HasColumnName("DATA_CADASTRO").IsRequired();           
            
        }
    }
}
