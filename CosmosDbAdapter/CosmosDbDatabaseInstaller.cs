using Microsoft.Azure.Cosmos;
using rest.Shared.Ports;

namespace CosmosDbAdapter
{
    internal class CosmosDbDatabaseInstaller : IDatabaseInstaller
    {
        private readonly string _databaseId;
        private readonly ICollection<string> _containerIds;
        private readonly CosmosClient _client;

        public CosmosDbDatabaseInstaller(CosmosDbOptions options)
        {
            _databaseId = options.DatabaseId ?? throw new ArgumentNullException($"{nameof(options.DatabaseId)}");
            _containerIds = options.ContainerIds;
            // TODO (fi): Client Factory
            var clientOptions = new CosmosClientOptions { ApplicationName = options.ApplicationName };
            _client = new CosmosClient(options.EndpointUri, options.PrimaryKey, clientOptions);
        }

        public async Task InstallDatabaseAsync()
        {
            await _client.CreateDatabaseIfNotExistsAsync(_databaseId);
        }

        public async Task SetupDatabaseTablseAsync()
        {
            var database = _client.GetDatabase(_databaseId);
            foreach (var containerId in _containerIds)
            {
                await database.CreateContainerIfNotExistsAsync(containerId, "/id");
            }            
        }
    }
}
