using CorretoraAPI.Models;
using CorretoraAPI.Models.Dto.Agent;
using CorretoraAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace CorretoraAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgentController : ControllerBase
    {
        private readonly IAgentRepository _agentRepository;
        public AgentController(IAgentRepository agentRepository)
        {
            _agentRepository = agentRepository;
        }
        [HttpGet]
        public async Task<IActionResult> index()
        {
            var query = await _agentRepository.GetAll();

            var AgentDto = query
            .Select(agent => new AgentDto
            {
                id = agent.Id,
                name = agent.Name,
                serial = agent.Serial,
                created_at = agent.CreatedAt,
                updated_at = agent.UpdateAt
            })
            .ToList();

            return AgentDto.Any() ?
             Ok(new { status = "success", data = AgentDto }) :
            BadRequest(new { status = "error", message = "Lista Vazia!" });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> get(int id)
        {
            Agent query = await _agentRepository.Get(id);
            return Ok(query);
        }

        [HttpPost]
        public async Task<IActionResult> createOrder([FromBody] Agent agent)
        {
            Agent query = await _agentRepository.Create(agent);

            return Ok(query);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> updateOrder(int id, [FromBody] Agent agent)
        {
            Agent query = await _agentRepository.Update(id, agent);
            return Ok(query);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> deleteOrder(int id)
        {
            bool query = await _agentRepository.Delete(id);
            return Ok(query);
        }
    }
}