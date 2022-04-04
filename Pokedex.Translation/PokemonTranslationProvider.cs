using Pokedex.Common;
using Pokedex.Common.Dto;
using Pokedex.Funtranslations.ApiClient;
using Pokedex.Funtranslations.ApiClient.Interface;
using Pokedex.Translation.Interfaces;

namespace Pokedex.Translation
{
    public class PokemonTranslationProvider : IPokemonTranslationProvider
    {
        private readonly ITranslationClient client;

        public PokemonTranslationProvider(ITranslationClient client)
        {
            this.client = client;
        }

        public Pokemon TranslateDescription(PokemonSpecies pokemonSpiecies)
        {
            var pokemon = PokemonConverter.ConvertPokemon(pokemonSpiecies);

            var translationOption = pokemon.IsLegendary || pokemon.Habitat == HabitatOptions.Cave ? TranslationOptions.Yoda : TranslationOptions.Shakespeare;
            try
            {
                pokemon = pokemon with { Description = client.Translate(pokemon.Description, translationOption).Result };
            }
            catch (Exception ex)
            { 
                //log exception
            }

            return pokemon;            
        }

        
    }
}