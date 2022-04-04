using Pokedex.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Translation.Interfaces
{
    public interface IPokemonTranslationProvider
    {
        Pokemon TranslateDescription(PokemonSpecies pokemonSpiecies);
    }
}
