using Backend.Dtos;
using Backend.Models;
using Backend.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private readonly ITeamRepository _teamRepository;

        public TeamsController(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Team>>> GetTeams()
        {
            var teams = await _teamRepository.GetAll();
            return Ok(teams);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Team>> GetTeam(int id)
        {
            var team = await _teamRepository.GetById(id);
            if (team == null)
            {
                return NotFound();
            }
            return Ok(team);
        }

        [HttpPost]
        public async Task<ActionResult<Team>> PostTeam(TeamCreateDto request)
        {
            var team = new Team
            {
                Name = request.Name,
                DepartmentId = request.DepartmentId
            };

            await _teamRepository.Add(team);
            await _teamRepository.SaveChanges();

            return Ok(team);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTeam(int id, TeamUpdateDto request)
        {
            var existingTeam = await _teamRepository.GetById(id);
            if (existingTeam == null)
            {
                return NotFound();
            }

            existingTeam.Name = request.Name;

            _teamRepository.Update(existingTeam, id);
            await _teamRepository.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeam(int id)
        {
            var team = await _teamRepository.GetById(id);
            if (team == null)
            {
                return NotFound();
            }

            _teamRepository.Remove(id);
            await _teamRepository.SaveChanges();

            return NoContent();
        }
    }
}
