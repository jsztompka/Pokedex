using Pokedex.Common.Base;
using Flurl;
using Flurl.Http;
using Newtonsoft.Json.Linq;
using Pokedex.Funtranslations.ApiClient.Interface;

namespace Pokedex.Funtranslations.ApiClient
{
    public class FunTranslationsClient : BaseClient, ITranslationClient
    {
        public FunTranslationsClient(string baseUrl) : base(baseUrl)
        {
        }

        public async Task<string> Translate(string textToTranslate, TranslationOptions option)
        {
            //NOTE I'm using a shortcut here to avoid defining a Dto for a single property in Production code I'd still define it 
            JObject response = await
             baseUrl
                 .AppendPathSegment(option.ToString().ToLower())
                 .PostJsonAsync(new { text = textToTranslate })
                 .ReceiveJson<JObject>();

            return response?.SelectToken("contents.translated").ToString();
                 
        }
        
    }
}