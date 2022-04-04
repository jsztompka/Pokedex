using Newtonsoft.Json;
using Pokedex.Common;
using Pokedex.Common.Dto;
using System.Collections.Generic;

// The Pokemon class was inspired from
// https://raw.githubusercontent.com/mtrdp642/PokeApiNet/master/PokeApiNet/Models/Pokemon.cs

namespace Pokedex.Common.Dto
{
    /// <summary>
    /// A Pokémon Species forms the basis for at least one Pokémon. Attributes
    /// of a Pokémon species are shared across all varieties of Pokémon within
    /// the species. A good example is Wormadam; Wormadam is the species which
    /// can be found in three different varieties, Wormadam-Trash,
    /// Wormadam-Sandy and Wormadam-Plant.
    /// </summary>
    public class PokemonSpecies 
    {
        /// <summary>
        /// The identifier for this resource.
        /// </summary>
        public int Id { get; set; }

        internal new static string ApiEndpoint { get; } = "pokemon-species";

        /// <summary>
        /// The name for this resource.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The order in which species should be sorted. Based on National Dex
        /// order, except families are grouped together and sorted by stage.
        /// </summary>
        public int Order { get; set; }

        /// <summary>
        /// The chance of this Pokémon being female, in eighths; or -1 for
        /// genderless.
        /// </summary>
        [JsonProperty("gender_rate")]
        public int GenderRate { get; set; }

        /// <summary>
        /// The base capture rate; up to 255. The higher the number, the easier
        /// the catch.
        /// </summary>
        [JsonProperty("capture_rate")]
        public int CaptureRate { get; set; }

        /// <summary>
        /// The happiness when caught by a normal Pokéball; up to 255. The higher
        /// the number, the happier the Pokémon.
        /// </summary>
        [JsonProperty("base_happiness")]
        public int BaseHappiness { get; set; }

        /// <summary>
        /// Whether or not this is a baby Pokémon.
        /// </summary>
        [JsonProperty("is_baby")]
        public bool IsBaby { get; set; }

        /// <summary>
        /// Whether or not this is a legendary Pokémon.
        /// </summary>
        [JsonProperty("is_legendary")]
        public bool IsLegendary { get; set; }

        /// <summary>
        /// Whether or not this is a mythical Pokémon.
        /// </summary>
        [JsonProperty("is_mythical")]
        public bool IsMythical { get; set; }

        /// <summary>
        /// Initial hatch counter: one must walk 255 × (hatch_counter + 1) steps
        /// before this Pokémon's egg hatches, unless utilizing bonuses like
        /// Flame Body's.
        /// </summary>
        [JsonProperty("hatch_counter")]
        public int HatchCounter { get; set; }

        /// <summary>
        /// Whether or not this Pokémon has visual gender differences.
        /// </summary>
        [JsonProperty("has_gender_differences")]
        public bool HasGenderDifferences { get; set; }

        /// <summary>
        /// Whether or not this Pokémon has multiple forms and can switch between
        /// them.
        /// </summary>
        [JsonProperty("forms_switchable")]
        public bool FormsSwitchable { get; set; }

        /// <summary>
        /// The habitat this Pokémon species can be encountered in.
        /// </summary>
        public NamedResource Habitat { get; set; }
        
        /// <summary>
        /// The flavor text of this ability listed in different languages.
        /// </summary>
        [JsonProperty("flavor_text_entries")]
        public List<AbilityFlavorText> FlavorTextEntries { get; set; }

    }

    public class NamedResource
    {
        /// <summary>
        /// The name of this resource
        /// </summary>
        public string Name { get; set; }
    }

    /// <summary>
    /// The flavor text for an ability
    /// </summary>
    public class AbilityFlavorText
    {
        /// <summary>
        /// The localized name for an API resource in a specific language.
        /// </summary>
        [JsonProperty("flavor_text")]
        public string FlavorText { get; set; }

        /// <summary>
        /// The language this text resource is in.
        /// </summary>
        public NamedResource Language { get; set; }

    }

    public class LanguageOptions
    { 
        public const string English = "en";
    }
    public class HabitatOptions
    {
        public const string Cave = "cave";
    }
















    ///// <summary>
    ///// Abilities provide passive effects for Pokémon in battle or in
    ///// the overworld. Pokémon have multiple possible abilities but
    ///// can have only one ability at a time.
    ///// </summary>
    //public class Ability : NamedApiResource
    //{
    //    /// <summary>
    //    /// The identifier for this resource.
    //    /// </summary>
    //    public override int Id { get; set; }

    //    internal new static string ApiEndpoint { get; } = "ability";

    //    /// <summary>
    //    /// The name for this resource.
    //    /// </summary>
    //    public override string Name { get; set; }

    //    /// <summary>
    //    /// Whether or not this ability originated in the main series of the video games.
    //    /// </summary>
    //    [JsonProperty("is_main_series")]
    //    public bool IsMainSeries { get; set; }

    //    /// <summary>
    //    /// The flavor text of this ability listed in different languages.
    //    /// </summary>
    //    [JsonProperty("flavor_text_entries")]
    //    public List<AbilityFlavorText> FlavorTextEntries { get; set; }

    //    /// <summary>
    //    /// A list of Pokémon that could potentially have this ability.
    //    /// </summary>
    //    public List<AbilityPokemon> Pokemon { get; set; }
    //}
       



    ///// <summary>
    ///// A mapping of an ability to a possible Pokémon
    ///// </summary>
    //public class AbilityPokemon
    //{
    //    /// <summary>
    //    /// Whether or not this a hidden ability for the referenced Pokémon.
    //    /// </summary>
    //    [JsonProperty("is_hidden")]
    //    public bool IsHidden { get; set; }

    //    /// <summary>
    //    /// Pokémon have 3 ability 'slots' which hold references to possible
    //    /// abilities they could have. This is the slot of this ability for the
    //    /// referenced pokemon.
    //    /// </summary>
    //    public int Slot { get; set; }

    //    /// <summary>
    //    /// The Pokémon this ability could belong to.
    //    /// </summary>
    //    public NamedApiResource<Pokemon> Pokemon { get; set; }
    //}

    

    ///// <summary>
    ///// Egg Groups are categories which determine which Pokémon are able
    ///// to interbreed. Pokémon may belong to either one or two Egg Groups.
    ///// </summary>
    //public class EggGroup : NamedApiResource
    //{
    //    /// <summary>
    //    /// The identifier for this resource.
    //    /// </summary>
    //    public override int Id { get; set; }

    //    internal new static string ApiEndpoint { get; } = "egg-group";

    //    /// <summary>
    //    /// The name for this resource.
    //    /// </summary>
    //    public override string Name { get; set; }

    //    /// <summary>
    //    ///	The name of this resource listed in different languages.
    //    /// </summary>
    //    public List<Names> Names { get; set; }

    //    /// <summary>
    //    /// A list of all Pokémon species that are members of this egg group.
    //    /// </summary>
    //    [JsonProperty("pokemon_species")]
    //    public List<NamedApiResource<PokemonSpecies>> PokemonSpecies { get; set; }
    //}

    ///// <summary>
    ///// Genders were introduced in Generation II for the purposes of
    ///// breeding Pokémon but can also result in visual differences or
    ///// even different evolutionary lines
    ///// </summary>
    //public class Gender : NamedApiResource
    //{
    //    /// <summary>
    //    /// The identifier for this resource.
    //    /// </summary>
    //    public override int Id { get; set; }

    //    internal new static string ApiEndpoint { get; } = "gender";

    //    /// <summary>
    //    /// The name for this resource.
    //    /// </summary>
    //    public override string Name { get; set; }

    //    /// <summary>
    //    /// A list of Pokémon species that can be this gender and how likely it
    //    /// is that they will be.
    //    /// </summary>
    //    [JsonProperty("pokemon_species_details")]
    //    public List<PokemonSpeciesGender> PokemonSpeciesDetails { get; set; }

    //    /// <summary>
    //    /// A list of Pokémon species that required this gender in order for a
    //    /// Pokémon to evolve into them.
    //    /// </summary>
    //    [JsonProperty("required_for_evolution")]
    //    public List<NamedApiResource<PokemonSpecies>> RequiredForEvolution { get; set; }
    //}

    ///// <summary>
    ///// A rate of chance of a Pokémon being a specific gender
    ///// </summary>
    //public class PokemonSpeciesGender
    //{
    //    /// <summary>
    //    /// The chance of this Pokémon being female, in eighths; or -1 for
    //    /// genderless.
    //    /// </summary>
    //    public int Rate { get; set; }

    //    /// <summary>
    //    /// A Pokémon species that can be the referenced gender.
    //    /// </summary>
    //    [JsonProperty("pokemon_species")]
    //    public NamedApiResource<PokemonSpecies> PokemonSpecies { get; set; }
    //}

    ///// <summary>
    ///// Growth rates are the speed with which Pokémon gain levels through experience.
    ///// </summary>
    //public class GrowthRate : NamedApiResource
    //{
    //    /// <summary>
    //    /// The identifier for this resource.
    //    /// </summary>
    //    public override int Id { get; set; }

    //    internal new static string ApiEndpoint { get; } = "growth-rate";

    //    /// <summary>
    //    /// The name for this resource.
    //    /// </summary>
    //    public override string Name { get; set; }

    //    /// <summary>
    //    /// The formula used to calculate the rate at which the Pokémon species
    //    /// gains level.
    //    /// </summary>
    //    public string Formula { get; set; }

    //    /// <summary>
    //    /// The descriptions of this characteristic listed in different languages.
    //    /// </summary>
    //    public List<Descriptions> Descriptions { get; set; }

    //    /// <summary>
    //    /// A list of levels and the amount of experienced needed to atain them
    //    /// based on this growth rate.
    //    /// </summary>
    //    public List<GrowthRateExperienceLevel> Levels { get; set; }

    //    /// <summary>
    //    /// A list of Pokémon species that gain levels at this growth rate.
    //    /// </summary>
    //    [JsonProperty("pokemon_species")]
    //    public List<NamedApiResource<PokemonSpecies>> PokemonSpecies { get; set; }
    //}

    ///// <summary>
    ///// Information of a level and how much experience is needed to get to it
    ///// </summary>
    //public class GrowthRateExperienceLevel
    //{
    //    /// <summary>
    //    /// The level gained.
    //    /// </summary>
    //    public int Level { get; set; }

    //    /// <summary>
    //    /// The amount of experience required to reach the referenced level.
    //    /// </summary>
    //    public int Experience { get; set; }
    //}
        

    ///// <summary>
    ///// The change information for a nature
    ///// </summary>
    //public class NatureStatChange
    //{
    //    /// <summary>
    //    /// The amount of change.
    //    /// </summary>
    //    [JsonProperty("max_changes")]
    //    public int MaxChange { get; set; }

        
    //}

    ///// <summary>
    ///// Move information for a battle style
    ///// </summary>
    //public class MoveBattleStylePreference
    //{
    //    /// <summary>
    //    /// Chance of using the move, in percent, if HP is under one half.
    //    /// </summary>
    //    [JsonProperty("low_hp_preference")]
    //    public int LowHpPreference { get; set; }

    //    /// <summary>
    //    /// Chance of using the move, in percent, if HP is over one half.
    //    /// </summary>
    //    [JsonProperty("high_hp_preference")]
    //    public int HighHpPreference { get; set; }
        
    //}

    

    ///// <summary>
    ///// Pokémon are the creatures that inhabit the world of the Pokémon games.
    ///// They can be caught using Pokéballs and trained by battling with other Pokémon.
    ///// Each Pokémon belongs to a specific species but may take on a variant which
    ///// makes it differ from other Pokémon of the same species, such as base stats,
    ///// available abilities and typings.
    ///// </summary>
    //public class Pokemon : NamedApiResource
    //{
    //    /// <summary>
    //    /// The identifier for this resource.
    //    /// </summary>
    //    public override int Id { get; set; }

    //    internal new static string ApiEndpoint { get; } = "pokemon";

    //    /// <summary>
    //    /// The name for this resource.
    //    /// </summary>
    //    public override string Name { get; set; }

    //    /// <summary>
    //    /// The base experience gained for defeating this Pokémon.
    //    /// </summary>
    //    [JsonProperty("base_experience")]
    //    public int BaseExperience { get; set; }

    //    /// <summary>
    //    /// The height of this Pokémon in decimetres.
    //    /// </summary>
    //    public int Height { get; set; }

    //    /// <summary>
    //    /// Set for exactly one Pokémon used as the default for each species.
    //    /// </summary>
    //    [JsonProperty("is_default")]
    //    public bool IsDefault { get; set; }

    //    /// <summary>
    //    /// Order for sorting. Almost national order, except families
    //    /// are grouped together.
    //    /// </summary>
    //    public int Order { get; set; }

    //    /// <summary>
    //    /// The weight of this Pokémon in hectograms.
    //    /// </summary>
    //    public int Weight { get; set; }

    //    /// <summary>
    //    /// A list of abilities this Pokémon could potentially have.
    //    /// </summary>
    //    public List<PokemonAbility> Abilities { get; set; }
             
                
    //    /// <summary>
    //    /// A link to a list of location areas, as well as encounter
    //    /// details pertaining to specific versions.
    //    /// </summary>
    //    [JsonProperty("location_area_encounters")]
    //    public string LocationAreaEncounters { get; set; }
                
    //    /// <summary>
    //    /// A set of sprites used to depict this Pokémon in the game.
    //    /// </summary>
    //    public PokemonSprites Sprites { get; set; }

    //    /// <summary>
    //    /// The species this Pokémon belongs to.
    //    /// </summary>
    //    public NamedApiResource<PokemonSpecies> Species { get; set; }

        

    //    /// <summary>
    //    /// A list of details showing types this Pokémon has.
    //    /// </summary>
    //    public List<PokemonType> Types { get; set; }
    //}

    ///// <summary>
    ///// A Pokémon ability
    ///// </summary>
    //public class PokemonAbility
    //{
    //    /// <summary>
    //    /// Whether or not this is a hidden ability.
    //    /// </summary>
    //    [JsonProperty("is_hidden")]
    //    public bool IsHidden { get; set; }

    //    /// <summary>
    //    /// The slot this ability occupies in this Pokémon species.
    //    /// </summary>
    //    public int Slot { get; set; }

    //    /// <summary>
    //    /// The ability the Pokémon may have.
    //    /// </summary>
    //    public NamedApiResource<Ability> Ability { get; set; }
    //}

    ///// <summary>
    ///// A Pokémon type
    ///// </summary>
    //public class PokemonType
    //{
    //    /// <summary>
    //    /// The order the Pokémon's types are listed in.
    //    /// </summary>
    //    public int Slot { get; set; }

    //    /// <summary>
    //    /// The type the referenced Pokémon has.
    //    /// </summary>
    //    public NamedApiResource<Type> Type { get; set; }
    //}       
    
    
    ///// <summary>
    ///// Pokémon sprite information
    ///// </summary>
    //public class PokemonSprites
    //{
    //    /// <summary>
    //    /// The default depiction of this Pokémon from the front in battle.
    //    /// </summary>
    //    [JsonProperty("front_default")]
    //    public string FrontDefault { get; set; }

    //    /// <summary>
    //    /// The shiny depiction of this Pokémon from the front in battle.
    //    /// </summary>
    //    [JsonProperty("front_shiny")]
    //    public string FrontShiny { get; set; }

    //    /// <summary>
    //    /// The female depiction of this Pokémon from the front in battle.
    //    /// </summary>
    //    [JsonProperty("front_female")]
    //    public string FrontFemale { get; set; }

    //    /// <summary>
    //    /// The shiny female depiction of this Pokémon from the front in battle.
    //    /// </summary>
    //    [JsonProperty("front_shiny_female")]
    //    public string FrontShinyFemale { get; set; }

    //    /// <summary>
    //    /// The default depiction of this Pokémon from the back in battle.
    //    /// </summary>
    //    [JsonProperty("back_default")]
    //    public string BackDefault { get; set; }

    //    /// <summary>
    //    /// The shiny depiction of this Pokémon from the back in battle.
    //    /// </summary>
    //    [JsonProperty("back_shiny")]
    //    public string BackShiny { get; set; }

    //    /// <summary>
    //    /// The female depiction of this Pokémon from the back in battle.
    //    /// </summary>
    //    [JsonProperty("back_female")]
    //    public string BackFemale { get; set; }

    //    /// <summary>
    //    /// The shiny female depiction of this Pokémon from the back in battle.
    //    /// </summary>
    //    [JsonProperty("back_shiny_female")]
    //    public string BackShinyFemale { get; set; }
    //}
       

    ///// <summary>
    ///// Colors used for sorting Pokémon in a Pokédex. The color listed in the
    ///// Pokédex is usually the color most apparent or covering each Pokémon's
    ///// body. No orange category exists; Pokémon that are primarily orange are
    ///// listed as red or brown.
    ///// </summary>
    //public class PokemonColor : NamedApiResource
    //{
    //    /// <summary>
    //    /// The identifier for this resource.
    //    /// </summary>
    //    public override int Id { get; set; }

    //    internal new static string ApiEndpoint { get; } = "pokemon-color";

    //    /// <summary>
    //    /// The name for this resource.
    //    /// </summary>
    //    public override string Name { get; set; }

    //    /// <summary>
    //    /// The name of this resource listed in different languages.
    //    /// </summary>
    //    public List<Names> Names { get; set; }

    //    /// <summary>
    //    /// A list of the Pokémon species that have this color.
    //    /// </summary>
    //    [JsonProperty("pokemon_species")]
    //    public List<NamedApiResource<PokemonSpecies>> PokemonSpecies { get; set; }
    //}

    

    ///// <summary>
    ///// Pokémon sprite information with relation to a form
    ///// </summary>
    //public class PokemonFormSprites
    //{
    //    /// <summary>
    //    /// The default depiction of this Pokémon form from the front in battle.
    //    /// </summary>
    //    [JsonProperty("front_default")]
    //    public string FrontDefault { get; set; }

    //    /// <summary>
    //    /// The shiny depiction of this Pokémon form from the front in battle.
    //    /// </summary>
    //    [JsonProperty("front_shiny")]
    //    public string FrontShiny { get; set; }

    //    /// <summary>
    //    /// The default depiction of this Pokémon form from the back in battle.
    //    /// </summary>
    //    [JsonProperty("back_default")]
    //    public string BackDefault { get; set; }

    //    /// <summary>
    //    /// The shiny depiction of this Pokémon form from the back in battle.
    //    /// </summary>
    //    [JsonProperty("back_shiny")]
    //    public string BackShiny { get; set; }
    //}

  

    ///// <summary>
    ///// Shapes used for sorting Pokémon in a Pokédex.
    ///// </summary>
    //public class PokemonShape : NamedApiResource
    //{
    //    /// <summary>
    //    /// The identifier for this resource.
    //    /// </summary>
    //    public override int Id { get; set; }

    //    internal new static string ApiEndpoint { get; } = "pokemon-shape";

    //    /// <summary>
    //    /// The name for this resource.
    //    /// </summary>
    //    public override string Name { get; set; }

    //    /// <summary>
    //    /// The "scientific" name of this Pokémon shape listed in
    //    /// different languages.
    //    /// </summary>
    //    [JsonProperty("awesome_names")]
    //    public List<AwesomeNames> AwesomeNames { get; set; }

    //    /// <summary>
    //    /// The name of this resource listed in different languages.
    //    /// </summary>
    //    public List<Names> Names { get; set; }

    //    /// <summary>
    //    /// A list of the Pokémon species that have this shape.
    //    /// </summary>
    //    [JsonProperty("pokemon_species")]
    //    public List<NamedApiResource<PokemonSpecies>> PokemonSpecies { get; set; }
    //}

    ///// <summary>
    ///// The "scientific" name for an API resource and the language information
    ///// </summary>
    //public class AwesomeNames
    //{
    //    /// <summary>
    //    /// The localized "scientific" name for an API resource in a
    //    /// specific language.
    //    /// </summary>
    //    [JsonProperty("awesome_name")]
    //    public string AwesomeName { get; set; }

    //    /// <summary>
    //    /// The language this "scientific" name is in.
    //    /// </summary>
    //    public NamedApiResource<Language> Language { get; set; }
    //}

    

    ///// <summary>
    ///// The flavor text for a Pokémon species
    ///// </summary>
    //public class PokemonSpeciesFlavorTexts
    //{
    //    /// <summary>
    //    /// The localized flavor text for an api resource in a specific language
    //    /// </summary>
    //    [JsonProperty("flavor_text")]
    //    public string FlavorText { get; set; }
        
    //    /// <summary>
    //    /// The language this flavor text is in.
    //    /// </summary>
    //    public NamedApiResource<Language> Language { get; set; }
    //}

    ///// <summary>
    ///// The genus information for a Pokémon and the associated language
    ///// </summary>
    //public class Genuses
    //{
    //    /// <summary>
    //    /// The localized genus for the referenced Pokémon species
    //    /// </summary>
    //    public string Genus { get; set; }

    //    /// <summary>
    //    /// The language this genus is in.
    //    /// </summary>
    //    public NamedApiResource<Language> Language { get; set; }
    //}

    ///// <summary>
    ///// Information for a PalPark area
    ///// </summary>
    //public class PalParkEncounterArea
    //{
    //    /// <summary>
    //    /// The base score given to the player when the referenced Pokémon is
    //    /// caught during a pal park run.
    //    /// </summary>
    //    [JsonProperty("base_score")]
    //    public int BaseScore { get; set; }

    //    /// <summary>
    //    /// The base rate for encountering the referenced Pokémon in this pal
    //    /// park area.
    //    /// </summary>
    //    public int Rate { get; set; }       
    //}

    ///// <summary>
    ///// A variety of a Pokémon species
    ///// </summary>
    //public class PokemonSpeciesVariety
    //{
    //    /// <summary>
    //    /// Whether this variety is the default variety.
    //    /// </summary>
    //    [JsonProperty("is_default")]
    //    public bool IsDefault { get; set; }

    //    /// <summary>
    //    /// The Pokémon variety.
    //    /// </summary>
    //    public NamedApiResource<Pokemon> Pokemon { get; set; }
    //}


    
    ///// <summary>
    ///// Types are properties for Pokémon and their moves. Each type has three
    ///// properties: which types of Pokémon it is super effective against,
    ///// which types of Pokémon it is not very effective against, and which types
    ///// of Pokémon it is completely ineffective against.
    ///// </summary>
    //public class Type : NamedApiResource
    //{
    //    /// <summary>
    //    /// The identifier for this resource.
    //    /// </summary>
    //    public override int Id { get; set; }

    //    internal new static string ApiEndpoint { get; } = "type";

    //    /// <summary>
    //    /// The name for this resource.
    //    /// </summary>
    //    public override string Name { get; set; }

    //    /// <summary>
    //    /// A detail of how effective this type is toward others and vice versa.
    //    /// </summary>
    //    [JsonProperty("damage_relations")]
    //    public TypeRelations DamageRelations { get; set; }

    //    /// <summary>
    //    /// The name of this resource listed in different languages.
    //    /// </summary>
    //    public List<Names> Names { get; set; }

    //    /// <summary>
    //    /// A list of details of Pokémon that have this type.
    //    /// </summary>
    //    public List<TypePokemon> Pokemon { get; set; }        
    //}

    ///// <summary>
    ///// A Pokémon type information
    ///// </summary>
    //public class TypePokemon
    //{
    //    /// <summary>
    //    /// The order the Pokémon's types are listed in.
    //    /// </summary>
    //    public int Slot { get; set; }

    //    /// <summary>
    //    /// The Pokémon that has the referenced type.
    //    /// </summary>
    //    public NamedApiResource<Pokemon> Pokemon { get; set; }
    //}

    ///// <summary>
    ///// The information for how a type interacts with other types
    ///// </summary>
    //public class TypeRelations
    //{
    //    /// <summary>
    //    /// A list of types this type has no effect on.
    //    /// </summary>
    //    [JsonProperty("no_damage_to")]
    //    public List<NamedApiResource<Type>> NoDamageTo { get; set; }

    //    /// <summary>
    //    /// A list of types this type is not very effect against.
    //    /// </summary>
    //    [JsonProperty("half_damage_to")]
    //    public List<NamedApiResource<Type>> HalfDamageTo { get; set; }

    //    /// <summary>
    //    /// A list of types this type is very effect against.
    //    /// </summary>
    //    [JsonProperty("double_damage_to")]
    //    public List<NamedApiResource<Type>> DoubleDamageTo { get; set; }

    //    /// <summary>
    //    /// A list of types that have no effect on this type.
    //    /// </summary>
    //    [JsonProperty("no_damage_from")]
    //    public List<NamedApiResource<Type>> NoDamageFrom { get; set; }

    //    /// <summary>
    //    /// A list of types that are not very effective against this type.
    //    /// </summary>
    //    [JsonProperty("half_damage_from")]
    //    public List<NamedApiResource<Type>> HalfDamageFrom { get; set; }

    //    /// <summary>
    //    /// A list of types that are very effective against this type.
    //    /// </summary>
    //    [JsonProperty("double_damage_from")]
    //    public List<NamedApiResource<Type>> DoubleDamageFrom { get; set; }
    //}
}