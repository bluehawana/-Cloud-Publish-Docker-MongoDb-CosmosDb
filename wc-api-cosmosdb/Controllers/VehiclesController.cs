using Microsoft.AspNetCore.Mvc;
using wc_api_cosmosdb.Models;
using wc_api_cosmosdb.Service;

namespace wc_api_cosmosdb.Controllers;

[ApiController]
[Route("api/v3/vehicles")]

public class VehiclesController : ControllerBase
{
    private readonly IVehicleService _service;
    public VehiclesController(IVehicleService service)
    {
        _service = service;

    }
    [HttpGet]
    public async Task<IActionResult> ListAllVehicles()
    {
        return Ok(await _service.ListAllVehiclesAsync());

    }
    [HttpPost]
    public async Task<IActionResult> CreateVehicle(Vehicle vehicle)
    {
        vehicle.Id = Guid.NewGuid().ToString();
        await _service.CreateVehiclesAsync(vehicle);
        return CreatedAtAction(nameof(ListAllVehicles), new { id = vehicle.Id }, vehicle);
    }
}

