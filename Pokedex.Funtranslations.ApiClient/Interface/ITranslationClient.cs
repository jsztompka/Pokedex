using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Funtranslations.ApiClient.Interface
{
    public interface ITranslationClient    
    {
        Task<string> Translate(string textToTranslate, TranslationOptions translationOptions);
    }
}
