using CorretoraAPI.Models;

namespace CorretoraAPI.Repositories.Interfaces
{
    public interface IHouseRepository
    {
        Task<List<House>> GetAll();
        Task<House> Get(int Id);
        Task<House> Create(House house);
        Task<House> Update(int Id, House house);
        Task<bool> Delete(int Id);

        
    }
}