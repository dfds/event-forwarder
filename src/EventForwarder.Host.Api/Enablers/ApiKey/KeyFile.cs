using System.Collections.Generic;

namespace AzureDevOpsJanitor.Host.EventForwarder.Enablers.ApiKey
{
    class KeyFile
    {
        public Dictionary<string, string> Keys { get; set; }

        public KeyFile()
        {
            Keys = new Dictionary<string, string>();
        }
    }
}