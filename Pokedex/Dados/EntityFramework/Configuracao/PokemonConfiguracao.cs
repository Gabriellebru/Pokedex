using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pokedex.Models;

namespace Pokedex.Dados.EntityFramework.Configuracao
{
    public class PokemonConfiguracao : IEntityTypeConfiguration<Pokemon>
    {
        public void Configure(EntityTypeBuilder<Pokemon> builder)
        {
            builder.ToTable("Pokemons","PG");
            builder.HasKey("PokemonId");
            builder.Property(t => t.PokemonId).HasColumnName("PokemonID").HasColumnType("int");
            builder.Property(t => t.Nome).HasColumnName("Nome").HasColumnType("varchar(255)");
            builder.Property(t => t.Descricao).HasColumnName("Descricao").HasColumnType("varchar(400)");
            builder.Property(t => t.Categoria).HasColumnName("Categoria").HasColumnType("varchar(50)");
            builder.Property(t => t.BaseExperiencia).HasColumnName("Experiencia_Base").HasColumnType("float");
            builder.Property(t => t.Peso).HasColumnName("Peso").HasColumnType("float");
            builder.Property(t => t.Altura).HasColumnName("Altura").HasColumnType("float");
            builder.Property(t => t.Tipo1).HasColumnName("Tipo_1").HasColumnType("varchar(50)");
            builder.Property(t => t.Tipo2).HasColumnName("Tipo_2").HasColumnType("varchar(50)");
            builder.Property(t => t.Habilidade1).HasColumnName("Habilidade_1").HasColumnType("varchar(50)");
            builder.Property(t => t.Habilidade2).HasColumnName("Habilidade_2").HasColumnType("varchar(50)");
            builder.Property(t => t.Movimento1).HasColumnName("Movimento_1").HasColumnType("varchar(50)");
            builder.Property(t => t.Movimento2).HasColumnName("Movimento_2").HasColumnType("varchar(50)");
            builder.Property(t => t.Movimento3).HasColumnName("Movimento_3").HasColumnType("varchar(50)");
            builder.Property(t => t.Movimento4).HasColumnName("Movimento_4").HasColumnType("varchar(50)");
            builder.Property(t => t.Url_Pokemon).HasColumnName("Url_Pokemon").HasColumnType("varchar(255)");
            builder.Property(t => t.Url_Sprite_front_default).HasColumnName("sprite_front_default_url").HasColumnType("varchar(400)");
            builder.Property(t => t.Url_Sprite_back_default).HasColumnName("sprite_back_default_url").HasColumnType("varchar(400)");
            builder.Property(t => t.Url_Sprite_front_female).HasColumnName("sprite_front_female_url").HasColumnType("varchar(400)");
            builder.Property(t => t.Url_Sprite_back_female).HasColumnName("sprite_back_female_url").HasColumnType("varchar(400)");
        }
    }
}
