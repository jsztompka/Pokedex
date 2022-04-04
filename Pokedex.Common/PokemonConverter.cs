using Pokedex.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Common
{
    public static class PokemonConverter
    {
        public static Pokemon ConvertPokemon(PokemonSpecies pokemonSpiecies)
        {
            //NOTE: in practice a better choice here might be Automapper esepcially on the larger objects

            return
                new Pokemon()
                {
                    Name = pokemonSpiecies.Name,
                    IsLegendary = pokemonSpiecies.IsLegendary,
                    Habitat = pokemonSpiecies.Habitat?.Name,
                    Description = FindEnglishDescription(pokemonSpiecies.FlavorTextEntries)
                };
        }

        private static string FindEnglishDescription(List<AbilityFlavorText> descriptions)
        {
            return descriptions?.FirstOrDefault(description => description.Language?.Name == LanguageOptions.English)?.FlavorText;
        }
    }
}
