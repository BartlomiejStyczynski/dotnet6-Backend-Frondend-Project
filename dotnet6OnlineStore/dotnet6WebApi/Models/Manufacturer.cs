namespace dotnet6WebApi.Models
{
    public class Manufacturer
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Bio { get; set; }
        public ICollection<Product>? Products { get; set; }

    }
}
