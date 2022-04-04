
//NOTE: In production code I'd apply appropriate namespaces to match company name/proj etc. 
using Flurl;
using Flurl.Http;
using Microsoft.Extensions.Options;
using Pokedex.Common.Base;
using Pokedex.PokemonApiClient.Exceptions;
using Pokedex.PokemonApiClient.Interfaces;
using System.Net;

namespace Pokedex.PokemonApiClient
{
    public class PokemonClient : BaseClient, IPokemonClient
    {
        private const string POKEMON_SPICIES = "pokemon-species";

        public PokemonClient(string baseUrl) : base(baseUrl) { }

        public async Task<Common.Dto.PokemonSpecies> GetPokemonSpecies(string name)
        {
            try
            {
                return await
                baseUrl.AppendPathSegment(POKEMON_SPICIES)
                    .AppendPathSegment(name)
                    .GetJsonAsync<Common.Dto.PokemonSpecies>();
            }
            catch (FlurlHttpException ex)
            {
                // TODO: add logging
                if (ex.StatusCode == (int)HttpStatusCode.NotFound)
                {
                    throw new PokemonNotFound();
                }
                
                throw;
            }
        }

    }
}