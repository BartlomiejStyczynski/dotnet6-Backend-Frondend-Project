using System.ComponentModel.DataAnnotations;

namespace dotnet6WebApi.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Decsription { get; set; }
        public int ISBN { get; set; }
        public Manufacturer? Manufacturer { get; set; }
        public Decimal Price { get; set; }
    }
}
