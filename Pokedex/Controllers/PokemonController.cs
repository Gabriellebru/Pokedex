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
            var BancoDados = new Contexto();
            List<Usuario> usuarios = BancoDados.Usuario.ToList();
            user = usuarios.Find(a => a.UsuarioID == id);
            if (user == null)
            {
                return RedirectToAction("Index","Home");
            }
            ViewBag.usuarioid = user.UsuarioID;
            List<Pokemon> Pokemons = BancoDados.Pokemon.ToList();
            Pokemon pokemon = Pokemons.Find(a => a.PokemonId == user.PokemonId);
            ViewBag.urlsprite = pokemon.Url_Sprite_front_default;
            ViewBag.pokemonid = user.PokemonId;

            return View(Pokemons);
        }
        public IActionResult Detalhes(int id, int usuarioid)
        {
            var db = new Contexto();
            Pokemon pokemon = db.Pokemon.Find(id);
            pokemon.Altura = pokemon.Altura * 10;
            List<Usuario> usuarios = db.Usuario.ToList();
            ViewBag.usuarioid = usuarios.Find(a => a.UsuarioID == usuarioid).UsuarioID;
            return View(pokemon);
        }
    }
}