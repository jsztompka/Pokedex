using Microsoft.AspNetCore.Mvc;
using Pokedex.Common;
using Pokedex.Common.Dto;
using Pokedex.PokemonApiClient.Exceptions;
using Pokedex.PokemonApiClient.Interfaces;
using Pokedex.Translation.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Pokedex.Api.Controllers
{
    [ApiController]
    [Route("pokemon/")]
    public class PokemonController : ControllerBase
    {
        private readonly IPokemonTranslationProvider translationProvider;
        private readonly IPokemonClient pokemonClient;
        private readonly ILogger<PokemonController> _logger;

        public PokemonController(IPokemonTranslationProvider translationProvider, IPokemonClient pokemonClient, ILogger<PokemonController> logger)
        {
            this.translationProvider = translationProvider;
            this.pokemonClient = pokemonClient;
            _logger = logger;
        }

        [HttpGet("{name}", Name = "Get pokemon by name or id")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Pokemon>> GetPokemon([Required] string name)
        {
            if (String.IsNullOrEmpty(name))
                return BadRequest("Pokemon name must be specified");

            try
            {
                var pokemonSpecies = await pokemonClient.GetPokemonSpecies(name);
                return Ok(PokemonConverter.ConvertPokemon(pokemonSpecies));
            }
            catch (PokemonNotFound ex)
            {
                return NotFound($"Pokemon {name} not found");
            }
        }

        [HttpGet("translated/{name}", Name = "Get translated pokemon description by id or name")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Pokemon>> GetTranslatedPokemon([Required] string name)
        {
            try
            {
                var pokemonSpecies = await pokemonClient.GetPokemonSpecies(name);

                return
                    Ok(translationProvider.TranslateDescription(pokemonSpecies));

            }
            catch (PokemonNotFound ex)
            {
                return NotFound($"Pokemon {name} not found");
            }
        }
    }
}