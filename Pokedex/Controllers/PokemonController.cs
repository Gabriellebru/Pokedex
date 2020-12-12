using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Pokedex.Dados.EntityFramework.Comum;
using Pokedex.Models;
using static Pokedex.Utilidades;

namespace Pokedex.Controllers
{
    public class PokemonController : Controller
    {
        Usuario user = new Usuario();
        public IActionResult Visualizar(int id)
        {
            Contexto db = new Contexto();
            user = db.Usuario.Find(id);
            if (user == null)
            {
                return RedirectToAction("Index","Home");
            }
            List<Pokemon> Pokemons = primeiraLetraMaiuscula( db.Pokemon.ToList());
            user.Nome = primeiraLetraMaiuscula(user.Nome);
            ViewBag.Usuario = user;
            return View(Pokemons);
        }
        public IActionResult Detalhes(int id, int usuarioid)
        {
            Contexto db = new Contexto();
            Pokemon pokemon = db.Pokemon.Find(id);
            pokemon.Altura = pokemon.Altura * 10;
            pokemon.Nome = primeiraLetraMaiuscula(pokemon.Nome);
            user = db.Usuario.Find(usuarioid);
            user.Nome = primeiraLetraMaiuscula(user.Nome);
            user.Pokemon = db.Pokemon.Find(user.PokemonId);

            ViewBag.Usuario = user;
            return View(pokemon);
        }
    }
}