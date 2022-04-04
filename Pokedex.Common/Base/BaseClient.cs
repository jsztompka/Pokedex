
namespace Pokedex.Common.Base
{
    /// <summary>
    /// Base class for API clients
    /// </summary>
    public abstract class BaseClient
    {
        protected readonly string baseUrl;

        public BaseClient(string baseUrl)
        {
            if (string.IsNullOrEmpty(baseUrl))
            {
                throw new ArgumentException($"'{nameof(baseUrl)}' cannot be null or empty.", nameof(baseUrl));
            }

            this.baseUrl = baseUrl;
        }
    }
}
