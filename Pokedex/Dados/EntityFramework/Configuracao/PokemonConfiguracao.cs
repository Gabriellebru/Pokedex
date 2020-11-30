using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pokedex.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pokedex.Dados.EntityFramework.Configuracao
{
    public class PokemonConfiguracao : IEntityTypeConfiguration<Pokemon>
    {
        public void Configure(EntityTypeBuilder<Pokemon> builder)
        {
            //Definição do nome e schema da tabela
            
            builder.ToTable("Pokemon", "PG");

            builder.HasKey("PokemonId");

            builder.Property(t => t.PokemonId).HasColumnName("PokemonId").HasColumnType("int");
            /*
            builder.Property(t => t.Nome).HasColumnName("Nome").HasColumnType("varchar(50)");
            builder.Property(t => t.Descricao).HasColumnName("Descricao").HasColumnType("varchar(255)");
            builder.Property(t => t.Categoria).HasColumnName("Categoria").HasColumnType("varchar(50)");
            builder.Property(t => t.BaseExperiencia).HasColumnName("BaseExperiencia").HasColumnType("float");
            builder.Property(t => t.Peso).HasColumnName("Peso").HasColumnType("float");
            builder.Property(t => t.Altura).HasColumnName("Altura").HasColumnType("float");
            builder.Property(t => t.Tipo1).HasColumnName("Tipo1").HasColumnType("varchar(50)");
            builder.Property(t => t.Tipo2).HasColumnName("Tipo2").HasColumnType("varchar(50)");
            builder.Property(t => t.Habilidade1).HasColumnName("Habilidade1").HasColumnType("varchar(50)");
            builder.Property(t => t.Habilidade2).HasColumnName("Habilidade2").HasColumnType("varchar(50)");
            builder.Property(t => t.Movimento1).HasColumnName("Movimento1").HasColumnType("varchar(50)");
            builder.Property(t => t.Movimento2).HasColumnName("Movimento2").HasColumnType("varchar(50)");
            builder.Property(t => t.Movimento3).HasColumnName("Movimento3").HasColumnType("varchar(50)");
            builder.Property(t => t.Movimento4).HasColumnName("Movimento4").HasColumnType("varchar(50)");
            builder.Property(t => t.Url_Pokemon).HasColumnName("Url_Pokemon").HasColumnType("varchar(255)");
            builder.Property(t => t.Url_Sprite).HasColumnName("Url_Sprite").HasColumnType("varchar(255)");
            */

        }
    }
}
