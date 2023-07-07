using CorretoraAPI.Models;

namespace CorretoraAPI.Repositories.Interfaces
{
    public interface ICustomerRepository{
        Task<List<Customer>> GetAll();
        Task<Customer> Get(int Id);
        Task<Customer> Create(Customer customer);
        Task<Customer> Update(int Id, Customer customer);
        Task<bool> Delete(int Id);
    }
}