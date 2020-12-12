using System.ComponentModel.DataAnnotations;

namespace Pokedex.Models
{
    public class Usuario
    {
        public int? UsuarioID { get; set; }
        [Required(ErrorMessage = "Esse campo é obrigatório")]
        public string Nome { get; set; }

        [MinLength(4,ErrorMessage ="Mínimo de 4 caracteres")]
        [MaxLength(20,ErrorMessage ="Máximo de 20 caracteres")]
        [Required(ErrorMessage ="Esse campo é obrigatório")]

        public string UsuarioAcesso { get; set; }

        [MinLength(4,ErrorMessage ="Mínimo de 4 caracteres")]
        [MaxLength(8,ErrorMessage ="Máximo de 8 caracteres")]
        [Required(ErrorMessage = "Esse campo é obrigatório")]

        public string SenhaAcesso { get; set; }

        [Required(ErrorMessage = "Esse campo é obrigatório")]
        public int? PokemonId { get; set; }
        public Pokemon Pokemon { get; set; }
    }
}
