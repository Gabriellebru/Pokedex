using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pokedex.Models;

namespace Pokedex
{
    public static class Utilidades
    {
        public static string primeiraLetraMaiuscula(string palavra)
        {
            return palavra.First().ToString().ToUpper() + palavra.Substring(1);
        } 
        public static Usuario primeiraLetraMaiuscula(Usuario usuario)
        {
            usuario.Nome = primeiraLetraMaiuscula(usuario.Nome);
            usuario.Pokemon.Nome = primeiraLetraMaiuscula(usuario.Pokemon.Nome);
            return usuario;
        }

        public static List<Pokemon> primeiraLetraMaiuscula(List<Pokemon> ListaPokemons)
        {
            foreach (Pokemon pokemon in ListaPokemons)
            {
                pokemon.Nome = primeiraLetraMaiuscula(pokemon.Nome);
            }
            return ListaPokemons;
        }
    }
}
