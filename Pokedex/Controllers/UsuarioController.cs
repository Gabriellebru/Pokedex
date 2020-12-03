using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Pokedex.Dados.EntityFramework.Comum;
using Pokedex.Models;

namespace Pokedex.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult Visualizar()
        {
            var BancoDados = new Contexto();
            List<Pokemon> pokemons = BancoDados.Pokemon.ToList();
            var Usuarios = BancoDados.Usuario.ToList();
            foreach (Usuario usuario in Usuarios)
            {
                usuario.Pokemon = pokemons.Find(a => a.PokemonId == usuario.PokemonId);
            }
            return View(Usuarios);
        }
        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Usuario objeto)
        { 
            var db = new Contexto();
            db.Usuario.Add(objeto);
            db.SaveChanges();
            return RedirectToAction("Visualizar");
        }
        public IActionResult Delete(int id)
        {
            var db = new Contexto();

            List<Usuario> usuarios  = db.Usuario.ToList();
            var usuario = usuarios.Find(a => a.UsuarioID == id);
            if (usuario == null)
            {
                throw new ArgumentNullException("Usuario", "O nome de usuário " + id + " não foi encontrado.");
            }
            db.Usuario.Remove(usuario);
            db.SaveChanges();
            return RedirectToAction("Visualizar");
        }

        public IActionResult Detalhes(int id)
        {
            var db = new Contexto();
            Usuario usuario = db.Usuario.Find(id);
            usuario.Pokemon = db.Pokemon.Find(usuario.PokemonId);
            return View(usuario);
        }

        /*
        public IActionResult Edit(Usuario usuario)
        {
            var db = new Contexto();
            var usuario = db.Usuario.Find(usuarioAcesso);
            return View(usuario);
        }
        */
    }
}