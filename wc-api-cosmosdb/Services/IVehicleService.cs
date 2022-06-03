using wc_api_cosmosdb.Models;

namespace wc_api_cosmosdb.Service
{
    public interface IVehicleService
    {
        Task<IList<Vehicle>> ListAllVehiclesAsync();
        Task CreateVehiclesAsync(Vehicle vehicle);

    }
}