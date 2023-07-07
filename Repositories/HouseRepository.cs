using CorretoraAPI.Data;
using CorretoraAPI.Models;
using CorretoraAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CorretoraAPI.Repositories
{
    public class HouseRepository : IHouseRepository
    {
        private readonly CorretoraDbContext _dbContext;
        public HouseRepository(CorretoraDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<House>> GetAll()
        {
            List<House> query = await _dbContext.Houses
            .Include(x => x.Customer)
            .Include(x => x.Agent)
            .ToListAsync();

            if (query.Count < 1) throw new Exception("Não há registros cadastrados!");
            return query;
        }
        public async Task<House> Get(int Id)
        {
            House query = await _dbContext.Houses
            .Include(x => x.Customer)
            .Include(x => x.Agent)
            .Include(x => x.Operations)
            .ThenInclude(x => x.Agent)
            .Include(x => x.Operations)
            .ThenInclude(x => x.Customer)
            .FirstOrDefaultAsync(h => h.Id == Id);

            if (query == null) throw new Exception("ID não encotrado!");

            return query;
        }
        public async Task<House> Create(House house)
        {
            _dbContext.Add(house);

            await _dbContext.SaveChangesAsync();

            return house;
        }

        public Task<House> Update(int Id, House house)
        {
            throw new NotImplementedException();
        }
        public Task<bool> Delete(int Id)
        {
            throw new NotImplementedException();
        }
    }
}