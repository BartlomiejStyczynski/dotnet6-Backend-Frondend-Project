using dotnet6WebApi.Data;
using dotnet6WebApi.Models;
using dotnet6WebApi.Services.Server;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace dotnet6WebApi.Services
{
    public class ManufacturerService : IManufacturerService
    {
        private readonly DataContext _context;

        public ManufacturerService(DataContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<ServerResponse<string>> DeleteManufacturerAsync(int id)
        {
            var response = new ServerResponse<string>();
            try
            {
                var manuToDelete = _context?.Manufacturers?.FirstAsync(m => m.Id == id);
                if(manuToDelete == null)
                {
                    response.Success = false;
                    response.Message = $"Manufacturer with ID:{id} not found.";
                    return response;
                }
                else
                {
                    _context!.Remove(manuToDelete);
                    await _context.SaveChangesAsync();
                }


                response.Data = $"";
            }
            catch (Exception)
            {

                throw;
            }

            return response;
        }

        public async Task<ServerResponse<Manufacturer>> GetManufacturer(int id)
        {
            var response = new ServerResponse<Manufacturer>();
            try
            {
                var manuInDb = await _context.Manufacturers.FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

        }

        public Task<ServerResponse<IEnumerable<Manufacturer>>> GetManufacturers()
        {
            throw new NotImplementedException();
        }

        public Task<ServerResponse<Manufacturer>> PostManufacturer(Manufacturer manufacturer)
        {
            throw new NotImplementedException();
        }

        public Task<ServerResponse<bool>> PutManufacturer(int id, Manufacturer manufacturer)
        {
            throw new NotImplementedException();
        }

    }
}
