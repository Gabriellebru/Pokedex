using System;
namespace Pokedex.Models
{
    public class Pokemon
    {
        public int PokemonId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Categoria { get; set; }
        public double? BaseExperiencia { get; set; }
        public double? Peso { get; set; }
        public double? Altura { get; set; }
        public string Tipo1 { get; set; }
        public string Tipo2 { get; set; }
        public string Habilidade1 { get; set; }
        public string Habilidade2 { get; set; }
        public string Movimento1 { get; set; }
        public string Movimento2 { get; set; }
        public string Movimento3 { get; set; }
        public string Movimento4 { get; set; }
        public string Url_Pokemon { get; set; }
        public string Url_Sprite_front_default { get; set; }
        public string Url_Sprite_back_default { get; set; }
        public string Url_Sprite_back_female { get; set; }
        public string Url_Sprite_front_female { get; set; }
    }
}
