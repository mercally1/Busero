using Busero.Models;
using Microsoft.EntityFrameworkCore;

namespace Busero.Data;

public class BusDbContext : DbContext
{
    public BusDbContext(DbContextOptions<BusDbContext> options) : base(options) 
    {

    }

    public DbSet<Bus> buses { get; set; }

    public DbSet<Driver> drivers { get; set; }
}
