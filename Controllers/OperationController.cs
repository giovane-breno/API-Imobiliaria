using AutoMapper;
using CorretoraAPI.Models;
using CorretoraAPI.Models.Dto.Operation;
using CorretoraAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CorretoraAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationController : ControllerBase
    {
        private readonly IOperationRepository _operationRepository;
        private readonly IMapper _mapper;
        public OperationController(IOperationRepository operationRepository, IMapper mapper)
        {
            _operationRepository = operationRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> index()
        {

            List<Operation> query = await _operationRepository.GetAll();
            var operationList = _mapper.Map<List<OperationListDto>>(query);

            return query != null
       ? Ok(new { status = "success", data = operationList })
       : BadRequest(new { status = "error", message = operationList });


        }

        [HttpGet("{id}")]
        public async Task<IActionResult> findOrder(int id)
        {
            Operation query = await _operationRepository.Get(id);
            return Ok(query);
        }

        [HttpPost]
        public async Task<IActionResult> createOrder([FromBody] Operation agent)
        {
            Operation query = await _operationRepository.Create(agent);
            return Ok(query);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Operation>> deleteOrder(int id)
        {
            bool query = await _operationRepository.Delete(id);
            return Ok(query);
        }
    }
}