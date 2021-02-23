using CloudEngineering.CodeOps.Infrastructure.AmazonWebServices;
using CloudEngineering.CodeOps.Infrastructure.AmazonWebServices.Commands.SimpleSystems.Parameter;
using System.Threading.Tasks;

namespace AzureDevOpsJanitor.Host.EventForwarder.Enablers.ApiKey
{
    public sealed class SsmApiKeyService : IApiKeyService
    {
        private readonly IAwsFacade _awsFacade;

        public SsmApiKeyService(IAwsFacade awsFacade)
        {
            _awsFacade = awsFacade;
        }

        public async Task<bool> IsAuthorized(string clientId, string apiKey)
        {
            var parameter = await _awsFacade.Execute(new GetParameterCommand(clientId));

            if (parameter.Value == apiKey)
            {
                return true; 
            }

            return false;
        }
    }
}