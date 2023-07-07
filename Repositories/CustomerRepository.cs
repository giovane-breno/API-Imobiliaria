using CorretoraAPI.Repositories.Interfaces;
using CorretoraAPI.Models;
using CorretoraAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace CorretoraAPI.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CorretoraDbContext _dbContext;
        public CustomerRepository(CorretoraDbContext dbContext){
            _dbContext = dbContext;
        }
        public async Task<List<Customer>> GetAll()
        {
            List<Customer> query = await _dbContext.Customers.ToListAsync();
            return query;
        }

        public async Task<Customer> Get(int Id)
        {
            Customer query = await _dbContext.Customers.FirstOrDefaultAsync(x => x.Id == Id);

            if (query == null) throw new Exception($"O cliente {Id} não foi encontrado!");
            return query;
        }

        public async Task<Customer> Create(Customer customer)
        {
            _dbContext.Add(customer);

            await _dbContext.SaveChangesAsync();

            return customer;
        }
        public Task<Customer> Update(int Id, Customer customer)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int Id)
        {
            throw new NotImplementedException();
        }

    }
}