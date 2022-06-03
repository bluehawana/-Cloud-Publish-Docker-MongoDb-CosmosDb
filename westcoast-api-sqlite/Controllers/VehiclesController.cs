using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class VehiclesController : ControllerBase
  {
    private readonly DataContext _context;
    public VehiclesController(DataContext context)
    {
      _context = context;
    }

    [HttpPost()]
    public async Task<IActionResult> AddVehicle(Vehicle vehicle)
    {
        await _context.Vehicles.AddAsync(vehicle);
        await _context.SaveChangesAsync();
        return StatusCode(201);
    }

    [HttpGet()]
    public async Task<ActionResult<List<Vehicle>>> ListAllVehicles(){
        var vehicles = await _context.Vehicles.ToListAsync();
        return Ok(vehicles);
    }
  }
}