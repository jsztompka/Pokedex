using Pokedex.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.PokemonApiClient.Interfaces
{
    public interface IPokemonClient
    {
        Task<PokemonSpecies> GetPokemonSpecies(string name);
    }
}
