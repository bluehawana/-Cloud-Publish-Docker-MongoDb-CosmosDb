using Microsoft.Azure.Cosmos;
using wc_api_cosmosdb.Models;

namespace wc_api_cosmosdb.Service;

public class VehicleService : IVehicleService
{
    private readonly Container _container;
    public VehicleService(CosmosClient client, string databaseName, string containerName)
    {
        _container = client.GetContainer(databaseName, containerName);
    }

    public async Task CreateVehiclesAsync(Vehicle vehicle)
    {
        await _container.CreateItemAsync(vehicle, new PartitionKey(vehicle.Id));
    }

    public Task<IList<Vehicle>> ListAllVehicles()
    {
        throw new NotImplementedException();
    }

    public async Task<IList<Vehicle>> ListAllVehiclesAsync()
    {
        var query = _container.GetItemQueryIterator<Vehicle>(new QueryDefinition("SELECT * FROM c"));
        var vehicles = new List<Vehicle>();

        while (query.HasMoreResults)
        {
            var response = await query.ReadNextAsync();
            vehicles.AddRange(response.ToList());
        }

        return vehicles;
    }
}
