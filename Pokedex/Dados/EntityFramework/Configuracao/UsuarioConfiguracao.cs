using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pokedex.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pokedex.Dados.EntityFramework.Configuracao
{
    public class UsuarioConfiguracao : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            //Definição do nome e schema da tabela
            builder.ToTable("Usuario", "PG");

            builder.HasKey("UsuarioID");

            builder.Property(t => t.UsuarioID).HasColumnName("UsuarioID").HasColumnType("int");
            builder.Property(t => t.Nome).HasColumnName("Nome").HasColumnType("varchar(100)").IsRequired();
            builder.Property(t => t.UsuarioAcesso).HasColumnName("UsuarioAcesso").HasColumnType("varchar(100)").IsRequired();
            builder.Property(t => t.SenhaAcesso).HasColumnName("SenhaAcesso").HasColumnType("char(8)").IsRequired();
            builder.Property(t => t.PokemonId).HasColumnName("PokemonId").HasColumnType("int");

        }
    }
}
