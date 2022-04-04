using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Pokedex.Api.Controllers;
using Pokedex.Common.Dto;
using Pokedex.Funtranslations.ApiClient.Interface;
using Pokedex.PokemonApiClient.Exceptions;
using Pokedex.PokemonApiClient.Interfaces;
using Pokedex.Translation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Pokedex.Tests
{
    public class PokemonControllerTests
    {
        private Mock<IPokemonTranslationProvider> translationProvider;
        private Mock<IPokemonClient> pokemonClient;
        private ILogger<PokemonController> logger;
        private PokemonController pokemonController;

        public PokemonControllerTests()
        {
            translationProvider = new Mock<IPokemonTranslationProvider>();
            pokemonClient = new Mock<IPokemonClient>();
            logger = Mock.Of<ILogger<PokemonController>>();
            pokemonController = new PokemonController(translationProvider.Object, pokemonClient.Object, logger);
        }

        [Fact]
        public async void GetPokemonTest()
        {
            var pokemonName = "mewtwo";
            var mewTwoSpecies = new PokemonSpecies(); 

            pokemonClient.Setup(x => x.GetPokemonSpecies(It.Is<string>(name => name == pokemonName))).ReturnsAsync(mewTwoSpecies);
            var response = await pokemonController.GetPokemon(pokemonName);

            response.Result.Should().BeOfType<OkObjectResult>();
            var result = ((OkObjectResult)response.Result).Value;
            result.Should().BeOfType<Pokemon>();
            pokemonClient.VerifyAll();           
        }

        [Fact]
        public async void GetPokemonNotFoundTest()
        {
            pokemonClient.Setup(x => x.GetPokemonSpecies(It.IsAny<string>())).Throws<PokemonNotFound>();
            var response = await pokemonController.GetPokemon(String.Empty);

            response.Result.Should().BeOfType<NotFoundObjectResult>();
        }

        [Fact]
        public async void GetPokemonTranslation()
        {
            var pokemonName = "mewtwo";
            var mewTwoSpecies = new PokemonSpecies();

            pokemonClient.Setup(x => x.GetPokemonSpecies(It.Is<string>(name => name == pokemonName))).ReturnsAsync(mewTwoSpecies);
            translationProvider.Setup(x => x.TranslateDescription(It.IsAny<PokemonSpecies>())).Returns(new Pokemon());
            var response = await pokemonController.GetTranslatedPokemon(pokemonName);

            response.Result.Should().BeOfType<OkObjectResult>();
            var result = ((OkObjectResult)response.Result).Value;
            result.Should().BeOfType<Pokemon>();
            pokemonClient.VerifyAll();

            translationProvider.VerifyAll();
        }       
    }
}
