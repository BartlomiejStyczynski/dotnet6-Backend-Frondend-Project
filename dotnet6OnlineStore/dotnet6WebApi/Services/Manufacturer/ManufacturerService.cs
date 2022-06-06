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
            catch (Exception e)
            {
                response.Success = false;
                response.Message = e.Message;
            }

            return response;
        }

        public async Task<ServerResponse<Manufacturer>> GetManufacturer(int id)
        {
            var response = new ServerResponse<Manufacturer>();
            try
            {
                var manuInDb = await _context.Manufacturers.FirstOrDefaultAsync(m => m.Id == id);
                if (manuInDb == null)
                {
                    response.Success = false;
                    response.Message = $"Manufacturer with ID:{id} not found.";
                }

                else
                {
                    response.Data = manuInDb;
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;

        }

        public async Task<ServerResponse<IEnumerable<Manufacturer>>> GetManufacturers()
        {
            var response = new ServerResponse<IEnumerable<Manufacturer>>();
            var manufacturersList = await _context.Manufacturers.ToListAsync();

            try
            {
                if (manufacturersList.Count == 0)
                {
                    response.Success = false;
                    response.Message = "No manufacturers found.";
                }

                else
                {
                    response.Data = manufacturersList;
                    response.Message = "List sent.";
                }
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = e.Message;
            }
            return response;
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
