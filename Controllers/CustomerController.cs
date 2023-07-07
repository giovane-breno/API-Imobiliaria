using CorretoraAPI.Models;
using CorretoraAPI.Models.Dto.Customer;
using CorretoraAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CorretoraAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        [HttpGet]
        public async Task<IActionResult> index()
        {

            var query = await _customerRepository.GetAll();
            var CustomerDto = query
            .Select(customer => new CustomerDto
            {
                id = customer.Id,
                name = customer.Name,
                age = customer.Age,
                created_at = customer.CreatedAt,
                updated_at = customer.UpdateAt
            }).ToList();

            return CustomerDto.Any() ?
            Ok(new { status = "success", data = CustomerDto }) :
            BadRequest(new { status = "error", message = query });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> findOrder(int id)
        {
            Customer query = await _customerRepository.Get(id);
            return Ok(query);
        }

        [HttpPost]
        public async Task<IActionResult> createOrder([FromBody] Customer customer)
        {
            Customer query = await _customerRepository.Create(customer);
            return Ok(query);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> deleteOrder(int id)
        {
            bool query = await _customerRepository.Delete(id);
            return Ok(query);
        }
    }
}