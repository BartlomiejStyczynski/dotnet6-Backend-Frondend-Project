using dotnet6WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnet6WebApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }

    }
}
