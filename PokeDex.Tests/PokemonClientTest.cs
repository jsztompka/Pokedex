using Flurl.Http.Testing;
using Pokedex.Common.Dto;
using Pokedex.PokemonApiClient;
using Pokedex.PokemonApiClient.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Pokedex.Tests
{
    public class PokemonClientTest
    {
        private string baseUrl;
        private PokemonClient client;

        public PokemonClientTest()
        {
            //this is fake url but is used for verification
            baseUrl = "https://testapi";
            client = new PokemonClient(baseUrl);
        }

        [Fact]
        public async Task GetSpeciesFromPokemonAPITestAsync()
        {
            using (var httpTest = new HttpTest())
            {
                httpTest.RespondWithJson(new PokemonSpecies());
                var pokemonName = "testName";
                var pokemonSpecies = await client.GetPokemonSpecies(pokemonName);

                httpTest.ShouldHaveCalled($"{baseUrl}/pokemon-species/{pokemonName}");

            }
        }

        [Fact]
        public async Task PokemonNotFoundTest()
        {
            using (var httpTest = new HttpTest())
            {
                httpTest.RespondWith("Pokemon not found", (int)HttpStatusCode.NotFound);
                var pokemonName = "testName";

                await Assert.ThrowsAsync<PokemonNotFound>(() => client.GetPokemonSpecies(pokemonName));
            }
        }
    }
}
