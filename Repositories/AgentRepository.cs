using CorretoraAPI.Models;
using CorretoraAPI.Repositories.Interfaces;
using CorretoraAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace CorretoraAPI.Repositories
{
    public class AgentRepository : IAgentRepository
    {
        private readonly CorretoraDbContext _dbContext;
        public AgentRepository (CorretoraDbContext dbContext){
            _dbContext = dbContext;
        }
        public async Task<List<Agent>> GetAll()
        {
            List<Agent> query = await _dbContext.Agents.ToListAsync();

            if (query == null) throw new Exception("Não há agentes cadastrados.");

            return query;
        }
        public async Task<Agent> Get(int Id)
        {
           Agent query = await _dbContext.Agents.FirstOrDefaultAsync(a => a.Id == Id);

           if (query == null) throw new Exception("Agente não encontrado");

           return query;
        }

        public async Task<Agent> Create(Agent agent)
        {
          _dbContext.Add(agent);

            await _dbContext.SaveChangesAsync();

            return agent;

        }

        public Task<Agent> Update(int Id, Agent agent)
        {
            throw new NotImplementedException();
        }
        public Task<bool> Delete(int Id)
        {
            throw new NotImplementedException();
        }
    }
}