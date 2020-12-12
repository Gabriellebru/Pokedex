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
        static Usuario user = new Usuario();
        public IActionResult Visualizar()
        {
            Contexto db = new Contexto();
            List<Usuario> Usuarios = db.Usuario.ToList();
            foreach (Usuario usuario in Usuarios)
            {
                usuario.Pokemon = db.Pokemon.Find(usuario.PokemonId);
            }
            return View(Usuarios);
        }
        public IActionResult Criar()
        {
            Contexto db = new Contexto();
            ViewBag.Pokemons = db.Pokemon.ToList();
            return View();
        }
        public IActionResult Detalhes(int id)
        {
            Contexto db = new Contexto();
            user = db.Usuario.Find(id);
            if(user == null)
            {
                return RedirectToAction("Login","Home");
            }
            user.Pokemon = db.Pokemon.Find(user.PokemonId);
            return View(user);
        }
        public IActionResult Editar(int id)
        {
            Contexto db = new Contexto();
            if (user.Nome == null || user.PokemonId == null || user.UsuarioAcesso == null || user.SenhaAcesso == null)
            {
                if (id == 0)
                {
                    return RedirectToAction("Visualizar");
                }
            user = db.Usuario.Find(id);

            }
            user.Pokemon = db.Pokemon.Find(user.PokemonId);
            ViewBag.pokemons = db.Pokemon.ToList();
            return View(user);
        }
        #endregion

        #region HttpPost
        [HttpPost]
        public IActionResult Criar(Usuario objeto)
        {
            Contexto db = new Contexto();
            if(objeto.Nome == null || objeto.SenhaAcesso == null || objeto.UsuarioAcesso == null || objeto.PokemonId == null)
            {
                ViewBag.Pokemons = db.Pokemon.ToList();
                return View(objeto);
            }
            db.Usuario.Add(objeto);
            db.SaveChanges();
            return RedirectToAction("Visualizar");
        }
        #endregion
        
        #region funções
        public IActionResult Delete(int id)
        {
            Contexto db = new Contexto();
            user = db.Usuario.Find(id);
            if (user == null)
            {
                throw new ArgumentNullException("Usuario", "O nome de usuário " + id + " não foi encontrado.");
            }
            db.Usuario.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Visualizar");
        }

        [HttpPost]
        public IActionResult Editar(Usuario usuario)
        {
            Contexto db = new Contexto();
            if (usuario.UsuarioAcesso == null || usuario.UsuarioID == null || usuario.Nome == null || usuario.SenhaAcesso == null)
            {
                user = usuario;
                user.Pokemon = db.Pokemon.Find(user.PokemonId);
                ViewBag.pokemons = db.Pokemon.ToList();
                ViewBag.Usuario = user;
                return View(user);
            }
            db.Usuario.Update(usuario);
            db.SaveChanges();
            return RedirectToAction("Detalhes",new { id = usuario.UsuarioID});
        }
        
        public IActionResult AlterarPokemon(int pokemonId, int usuarioId)
        {
            Contexto db = new Contexto();
            user = db.Usuario.Find(usuarioId);
            user.PokemonId = pokemonId;
            db.Usuario.Update(user);
            db.SaveChanges();
            return RedirectToAction("Visualizar","Pokemon",new {id = user.UsuarioID });
        }

        #endregion
    }
}