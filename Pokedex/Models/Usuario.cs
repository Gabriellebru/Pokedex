using System;
using System.ComponentModel.DataAnnotations;

namespace Pokedex.Models
{
    public class Usuario
    {
        public int? UsuarioID { get; set; }
        public string Nome { get; set; }

        [Required(ErrorMessage ="Esse campo é obrigatório")]
        public string UsuarioAcesso { get; set; }
        [Required(ErrorMessage = "Esse campo é obrigatório")]
        public string SenhaAcesso { get; set; }
        [Required(ErrorMessage = "Esse campo é obrigatório")]
        public int? PokemonId { get; set; }
        public Pokemon Pokemon { get; set; }
    }
}
