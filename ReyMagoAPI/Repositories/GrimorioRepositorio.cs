using Microsoft.EntityFrameworkCore;
using ReyMagoApi.DataAccess;
using ReyMagoApi.Entities;
using ReyMagoAPI.Core.Interfaces;

namespace ReyMagoAPI.Repositories
{
    public class GrimorioRepositorio : IGrimorioRepository
    {
        private readonly AppDbContext _context;
        public GrimorioRepositorio(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Grimorio>> GetGrimorios()
        {
            return await _context.Set<Grimorio>().ToListAsync();
        }
    }
}
