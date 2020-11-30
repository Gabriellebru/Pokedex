using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pokedex.Dados.EntityFramework.Comum;
using Pokedex.Models;

namespace Pokedex.Controllers
{
    public class PokemonController : Controller
    {
        public IActionResult Visualizar()
        {
            var BancoDados = new Contexto();
            var Pokemons = BancoDados.Pokemon.ToList();
            return View(Pokemons);
        }
        public IActionResult Detalhes(int id)
        {
            var db = new Contexto();
            Pokemon pokemon = db.Pokemon.Find(id);
            pokemon.Altura = pokemon.Altura * 10;
            return View(pokemon);
        }
    }
}