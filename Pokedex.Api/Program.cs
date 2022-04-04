using Pokedex.Common.Configuration;
using Pokedex.Funtranslations.ApiClient;
using Pokedex.Funtranslations.ApiClient.Interface;
using Pokedex.PokemonApiClient;
using Pokedex.PokemonApiClient.Interfaces;
using Pokedex.Translation;
using Pokedex.Translation.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var config = builder.Configuration;
builder.Services.AddScoped<IPokemonClient, PokemonClient>(_ => 
    new PokemonClient(
            config.GetSection(PokemonApiConfiguration.Section).Get<PokemonApiConfiguration>().ApiEndpoint)); 

builder.Services.AddScoped<ITranslationClient, FunTranslationsClient>(_ => new FunTranslationsClient(
    config.GetSection(FunTranslationsApiConfiguration.FunTranslationApiSection).Get<FunTranslationsApiConfiguration>().ApiEndpoint));
builder.Services.AddScoped<IPokemonTranslationProvider, PokemonTranslationProvider>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
