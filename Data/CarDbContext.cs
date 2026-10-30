using CarManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace CarManagementSystem.Data;

public class CarDbContext(DbContextOptions<CarDbContext> options) : DbContext(options)
{
    public DbSet<Car> Cars => Set<Car>();
}
