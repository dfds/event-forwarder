using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace AzureDevOpsJanitor.Host.EventForwarder.Enablers.ApiKey
{
    public sealed class InMemoryApiKeyService : IApiKeyService
    {
        private readonly IReadOnlyDictionary<string, string> _keys;

        public InMemoryApiKeyService(IDictionary<string, string> keys = default)
        {
            _keys = new ReadOnlyDictionary<string, string>(keys ?? new Dictionary<string, string>());
        }

        public Task<bool> IsAuthorized(string clientId, string apiKey)
        {
            if (_keys.ContainsKey(clientId) && _keys[clientId] == apiKey)
            {
                return Task.FromResult(true);
            }

            return Task.FromResult(false);
        }
    }
}