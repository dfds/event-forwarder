using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace AzureDevOpsJanitor.Host.EventForwarder.Enablers.ApiKey
{
    public sealed class FileApiKeyService : IApiKeyService
    {
        private readonly KeyFile _keyFile;

        public FileApiKeyService(string filePath = "apiKey.json")
        {
            string content = string.Empty;

            if (File.Exists(filePath))
            {
                content = File.ReadAllText(filePath);
            }

            _keyFile = JsonSerializer.Deserialize<KeyFile>(content);
        }

        public Task<bool> IsAuthorized(string clientId, string apiKey)
        {
            if (_keyFile.Keys.ContainsKey(apiKey))
            {
                if (_keyFile.Keys[apiKey] == clientId)
                {
                    return Task.FromResult(true);
                }

                return Task.FromResult(false);
            }

            return Task.FromResult(false);
        }
    }
}