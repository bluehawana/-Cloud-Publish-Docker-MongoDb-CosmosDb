
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Data;
public class DataContext : DbContext
{
  public DbSet<Vehicle> Vehicles => Set<Vehicle>();
  public DataContext(DbContextOptions options) : base(options)
  {
  }
}