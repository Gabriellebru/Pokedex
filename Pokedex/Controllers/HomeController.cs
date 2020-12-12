using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using Microsoft.Extensions.Logging;
using Pokedex.Dados.EntityFramework.Comum;
using Pokedex.Models;
using static Pokedex.Utilidades;

namespace Pokedex.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        static Usuario usuario = new Usuario();
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [HttpPost]
        public IActionResult Login(Usuario user)
        {
            Contexto db = new Contexto();
            List<Usuario> usuarios = db.Usuario.ToList();
            usuario = usuarios.Find(a => a.UsuarioAcesso == user.UsuarioAcesso && a.SenhaAcesso == user.SenhaAcesso);
            if (usuario != null)
            {
                return RedirectToAction("Visualizar", "Pokemon", new { id = usuario.UsuarioID });
            }
            usuario = usuarios.Find(a => a.UsuarioAcesso == user.UsuarioAcesso);
            if(user.UsuarioAcesso != null)
            {
                if(user.SenhaAcesso != usuario.SenhaAcesso)
                {
                    ModelState.AddModelError("SenhaAcesso", "Verifique a sua senha");
                }
            }
            return View(user);
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Cadastro()
        {
            var db = new Contexto();
            ViewBag.Pokemons = primeiraLetraMaiuscula(db.Pokemon.ToList());
            return View();
        }

        [HttpPost]
        public IActionResult Cadastro(Usuario objeto)
        {
            var db = new Contexto();
            if(objeto.Nome == null || objeto.UsuarioAcesso == null || objeto.SenhaAcesso == null || objeto.PokemonId == null)
            {
                ViewBag.Pokemons = db.Pokemon.ToList();
                return View(objeto);
            }
            db.Usuario.Add(objeto);
            db.SaveChanges();
            return RedirectToAction("Login");
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
