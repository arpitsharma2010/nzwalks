using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers
{
    [ApiController]
    [Route("WalkDifficulty")]
    public class WalkDifficultyController : Controller
    {
        private readonly IWalkDifficultyRepository walkDifficultyRepository;
        private readonly IMapper mapper;

        public WalkDifficultyController(IWalkDifficultyRepository walkDifficultyRepository, IMapper mapper)
        {
            this.walkDifficultyRepository = walkDifficultyRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var domain = await walkDifficultyRepository.GetAllAsync();

            var dto = mapper.Map<List<Models.DTO.WalkDifficultyDTO>>(domain);

            return Ok(dto);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetWalkDifficultyAsync(Guid id)
        {
            var walkDifficulty = await walkDifficultyRepository.GetWalkDifficultyAsync(id);

            if (walkDifficulty == null)
            {
                return NotFound();
            }

            var diffcultyDTO = mapper.Map<Models.DTO.WalkDifficultyDTO>(walkDifficulty);

            return Ok(diffcultyDTO);
        }

        [HttpPost]
        public async Task<IActionResult> AddWalkDifficultyAsync(AddWalkDifficultyRequest addWalkDifficultyRequest)
        {
            var domain = mapper.Map<WalkDifficulty>(addWalkDifficultyRequest);

            domain = await walkDifficultyRepository.AddWalkDifficultyAsync(domain);

            var dto = mapper.Map<WalkDifficultyDTO>(domain);

            return Ok(dto);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> AddWalkDifficultyAsync(
            [FromRoute] Guid id,
            [FromBody] UpdateWalkDifficultyRequest updateWalkDifficultyRequest)
        {
            var domain = mapper.Map<WalkDifficulty>(updateWalkDifficultyRequest);

            domain = await walkDifficultyRepository.UpdateWalkDifficultyAsync(id, domain);

            if(domain == null)
            {
                return NotFound();
            }

            var dto = mapper.Map<WalkDifficultyDTO>(domain);

            return Ok(dto);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> AddWalkDifficultyAsync([FromRoute] Guid id)
        {
            var domain = await walkDifficultyRepository.DeleteWalkDifficultyAsync(id);

            if (domain == null)
            {
                return NotFound();
            }

            var dto = mapper.Map<WalkDifficultyDTO>(domain);

            return Ok(dto);
        }
    }
}
