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
        #region Views
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
        public IActionResult Detalhes(int id)
        {
            var db = new Contexto();
            List<Usuario> usuarios = db.Usuario.ToList();
            Usuario usuario = usuarios.Find(a => a.UsuarioID == id);
            usuario.Pokemon = db.Pokemon.Find(usuario.PokemonId);
            return View(usuario);
        }
        #endregion

        #region HttpPost
        [HttpPost]
        public IActionResult Create(Usuario objeto)
        {
            var db = new Contexto();
            List<Usuario> users = db.Usuario.ToList();
            Usuario user = users.Find(a => a.UsuarioAcesso == objeto.UsuarioAcesso);
            if (user != null)
            {
                return RedirectToAction("Criar");
            }
            db.Usuario.Add(objeto);
            db.SaveChanges();
            return RedirectToAction("Visualizar");
        }
        #endregion
        
        #region funções
        public IActionResult Delete(int id)
        {
            var db = new Contexto();

            List<Usuario> usuarios = db.Usuario.ToList();
            var usuario = usuarios.Find(a => a.UsuarioID == id);
            if (usuario == null)
            {
                throw new ArgumentNullException("Usuario", "O nome de usuário " + id + " não foi encontrado.");
            }
            db.Usuario.Remove(usuario);
            db.SaveChanges();
            return RedirectToAction("Visualizar");
        }

        public IActionResult Editar(int id)
        {
            Contexto db = new Contexto();
            List<Usuario> usuarios = db.Usuario.ToList();
            Usuario usuario = usuarios.Find(a => a.UsuarioID == id);
            ViewBag.pokemons = db.Pokemon.ToList();
            return View(usuario);
        }

        public IActionResult Edit(Usuario usuario)
        {
            var db = new Contexto();
            if (usuario.UsuarioAcesso == null || usuario.UsuarioID == null || usuario.Nome == null || usuario.SenhaAcesso == null)
            {
                return RedirectToAction("Editar", new { id = usuario.UsuarioID });
            }
            db.Usuario.Update(usuario);
            db.SaveChanges();
            return RedirectToAction("Visualizar");
        }
        
        #endregion
    }
}