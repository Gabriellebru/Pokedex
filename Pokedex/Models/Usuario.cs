using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pokedex.Models
{
    public class Usuario
    {
        public int? UsuarioID { get; set; }
        public string Nome { get; set; }
        public string UsuarioAcesso { get; set; }
        public string SenhaAcesso { get; set; }
        public int? PokemonId { get; set; }

        public Pokemon Pokemon { get; set; }
    }
}
