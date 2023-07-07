using CorretoraAPI.Repositories.Interfaces;
using CorretoraAPI.Data;
using CorretoraAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CorretoraAPI.Repositories
{
    public class OperationRepository : IOperationRepository
    {
        private readonly CorretoraDbContext _dbContext;
        public OperationRepository(CorretoraDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Operation>> GetAll()
        {
            List<Operation> query = await _dbContext.Operations
            .Include(o => o.House)
            .Include(o => o.Agent)
            .Include(O => O.Customer)
            .ToListAsync();

            if (query.Count < 1) throw new Exception("Não há operações cadastradas!");

            return query;
        }
        public async Task<Operation> Get(int Id)
        {
            Operation query = await _dbContext.Operations.FirstOrDefaultAsync(x => x.Id == Id);

            if (query == null) throw new Exception("Esse id nao foi encontrado");

            return query;
        }

        public async Task<Operation> Create(Operation operation)
        {
            _dbContext.Add(operation);

            await _dbContext.SaveChangesAsync();

            return operation;

        }
        public Task<bool> Delete(int Id)
        {
            throw new NotImplementedException();
        }


    }
}
