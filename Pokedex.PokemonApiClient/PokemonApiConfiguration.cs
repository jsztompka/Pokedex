using Pokedex.Common.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.PokemonApiClient
{
    /// <summary>
    /// The purpose of this class is to provide all special configuration options for the Pokemon API client
    /// </summary>
    public class PokemonApiConfiguration : ApiOptions
    {
        public const string Section = "PokemonAPI";
    }
}
