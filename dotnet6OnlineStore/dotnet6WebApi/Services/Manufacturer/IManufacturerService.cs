using dotnet6WebApi.Models;
using dotnet6WebApi.Services.Server;
using Microsoft.AspNetCore.Mvc;

namespace dotnet6WebApi.Services
{
    public interface IManufacturerService
    {
        Task<ServerResponse<IEnumerable<Manufacturer>>> GetManufacturers();
        Task<ServerResponse<Manufacturer>> GetManufacturer(int id);
        Task<ServerResponse<bool>> PutManufacturer(int id, Manufacturer manufacturer);
        Task<ServerResponse<Manufacturer>> PostManufacturer(Manufacturer manufacturer);
        Task<ServerResponse<string>> DeleteManufacturerAsync(int id);

    }
}
