using CorretoraAPI.Models;

namespace CorretoraAPI.Repositories.Interfaces
{
    public interface IAgentRepository
    {
        Task<List<Agent>> GetAll();
        Task<Agent> Get(int Id);
        Task<Agent> Create(Agent agent);
        Task<Agent> Update(int Id, Agent agent);
        Task<bool> Delete(int Id);

    }
}