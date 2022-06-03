using Microsoft.Azure.Cosmos;
using wc_api_cosmosdb.Service;

namespace wc_api_cosmosdb.Models;

public static class CosmosInitializeDatabase
{
    public static async Task<VehicleService> InitializeDatabase(IConfigurationSection settings)
    {
        var client = new CosmosClient(settings["Account"], settings["Key"]);
        var database = await client.CreateDatabaseIfNotExistsAsync(settings["DatabaseName"]);
        await database.Database.CreateContainerIfNotExistsAsync(settings["ContainerName"], "/id");

        var vehicleService = new VehicleService(client, settings["DatabaseName"], settings["ContainerName"]);
        return vehicleService;

    }
}
