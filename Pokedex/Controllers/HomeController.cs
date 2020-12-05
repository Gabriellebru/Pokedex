using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pokedex.Dados.EntityFramework.Comum;
using Pokedex.Models;

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

        public IActionResult Login(Usuario user)
        {
            var db = new Contexto();
            List<Usuario> usuarios = db.Usuario.ToList();
            usuario = usuarios.Find(a => a.UsuarioAcesso == user.UsuarioAcesso && a.SenhaAcesso == user.SenhaAcesso);
            if (usuario != null)
            {
                return RedirectToAction("Detalhes", "Usuario", new { id = usuario.UsuarioID });
            }
            return RedirectToAction("Index");
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Cadastro()
        {
            var db = new Contexto();
            ViewBag.Pokemons = db.Pokemon.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(Usuario objeto)
        {
            var db = new Contexto();
            List<Usuario> users = db.Usuario.ToList();
            Usuario user = users.Find(a => a.UsuarioAcesso == objeto.UsuarioAcesso);
            if (user == null)
            {
                db.Usuario.Add(objeto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Cadastro");
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
