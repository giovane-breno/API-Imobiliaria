using CorretoraAPI.Models;
using CorretoraAPI.Models.Dto;

namespace CorretoraAPI.Repositories.Interfaces
{
    public interface IOperationRepository
    {
        Task<List<Operation>> GetAll();
        Task<Operation> Get(int Id);
        Task<Operation> Create(Operation operation);
        Task<bool> Delete(int Id);

        
    }
}