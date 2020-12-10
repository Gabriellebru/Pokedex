using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Pokedex.Dados.EntityFramework.Comum;
using Pokedex.Models;

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
            List<Pokemon> Pokemons = db.Pokemon.ToList();
            ViewBag.Usuario = user;
            return View(Pokemons);
        }
        public IActionResult Detalhes(int id, int usuarioid)
        {
            var db = new Contexto();
            Pokemon pokemon = db.Pokemon.Find(id);
            pokemon.Altura = pokemon.Altura * 10;
            user = db.Usuario.Find(usuarioid);
            user.Pokemon = db.Pokemon.Find(user.PokemonId);
            ViewBag.Usuario = user;
            return View(pokemon);
        }
    }
}