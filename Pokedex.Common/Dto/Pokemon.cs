using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Common.Dto
{
    public record Pokemon
    {
        public string Name { get; init; }
        public bool IsLegendary { get; init; }

        public string Habitat { get; init; }

        public string Description { get; init; }

        
    }
}
