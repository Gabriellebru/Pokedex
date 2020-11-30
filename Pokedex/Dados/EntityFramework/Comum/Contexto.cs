using Microsoft.EntityFrameworkCore;
using Pokedex.Dados.EntityFramework.Configuracao;
using Pokedex.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pokedex.Dados.EntityFramework.Comum
{
    public class Contexto : DbContext
    {
        public DbSet<Pokemon> Pokemon { get; set; }
        public DbSet<Usuario> Usuario { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PokemonConfiguracao());
            modelBuilder.ApplyConfiguration(new UsuarioConfiguracao());

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"
                Data source = 201.62.57.93;
                database = dbPICC_20202;
                user id = laboratorio;
                password = @laboratorio*;
            ");

        }


    }
}
