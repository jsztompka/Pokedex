using Flurl.Http.Testing;
using Pokedex.Funtranslations.ApiClient;
using Pokedex.Funtranslations.ApiClient.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Pokedex.Tests
{
    public class FunTranslationsClientTest
    {
        private string baseUrl;
        private ITranslationClient client;

        public FunTranslationsClientTest()
        {
            //this is fake url but is used for verification
            baseUrl = "https://testapi";
            client = new FunTranslationsClient(baseUrl);
        }

        [Fact]
        public async Task GetSpeciesFromPokemonAPITestAsync()
        {
            using (var httpTest = new HttpTest())
            {
                var textToTranslate = "to be or not to be";
                    
                var pokemonSpecies = await client.Translate(textToTranslate, TranslationOptions.Yoda);

                httpTest.ShouldHaveCalled($"{baseUrl}/yoda"); //.WithVerb(HttpMethod.Post).WithRequestJson(new { text = textToTranslate });
            };
        }
    }
    
}
