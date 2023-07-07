using CorretoraAPI.Models;
using CorretoraAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using CorretoraAPI.Models.Dto.House;
using AutoMapper;

namespace CorretoraAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HouseController : ControllerBase
    {
        private readonly IHouseRepository _houseRepository;
        private readonly IMapper _mapper;
        public HouseController(IHouseRepository houseRepository, IMapper mapper)
        {
            _houseRepository = houseRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> index()
        {
            var query = await _houseRepository.GetAll();
            var houseList = _mapper.Map<List<HouseListDto>>(query);


            return query != null
            ? Ok(new { status = "success", data = houseList })
            : BadRequest(new { status = "error", message = query });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> findOrder(int id)
        {
            House query = await _houseRepository.Get(id);
            var HouseDto = _mapper.Map<HouseDto>(query);

            return HouseDto != null
            ? Ok(new { status = "success", data = HouseDto })
            : BadRequest(new { status = "error", message = HouseDto });
        }

        [HttpPost]
        public async Task<IActionResult> createOrder([FromBody] House house)
        {
            House query = await _houseRepository.Create(house);
            return Ok(query);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> deleteOrder(int id)
        {
            bool query = await _houseRepository.Delete(id);
            return Ok(query);
        }
    }
}