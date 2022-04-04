using Pokedex.Funtranslations.ApiClient.Interface;
using Xunit;
using Moq;
using Pokedex.Translation;
using Pokedex.Common.Dto;
using Pokedex.Funtranslations.ApiClient;
using System.Collections.Generic;

namespace PokeDex.Tests
{
    public class PokemonTranslationProviderTests
    {
        Mock<ITranslationClient> translationClient;

        
        public PokemonTranslationProviderTests()
        {
            translationClient = new Mock<ITranslationClient>();         
        }

        [Theory]
        [InlineData(HabitatOptions.Cave, true, TranslationOptions.Yoda)]
        [InlineData(HabitatOptions.Cave, false, TranslationOptions.Yoda)]
        [InlineData("Lewisham", true, TranslationOptions.Yoda)]
        [InlineData("Lewisham", false, TranslationOptions.Shakespeare)]
        public void VerifyTranslationLogic(string habitatName, bool isLegendary, TranslationOptions translationOption)
        {
            var pokemonTranslationProvider = new PokemonTranslationProvider(translationClient.Object);

            pokemonTranslationProvider.TranslateDescription(new PokemonSpecies() { IsLegendary = isLegendary, Habitat = new NamedResource { Name = habitatName }, FlavorTextEntries = new List<AbilityFlavorText>() });

            translationClient.Verify(x=> x.Translate(It.IsAny<string>(), translationOption));
        }

    }
}