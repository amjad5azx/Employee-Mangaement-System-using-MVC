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
    public class RolesController : ControllerBase
    {
        private readonly IRoleRepository _roleRepository;

        public RolesController(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Role>>> GetRoles()
        {
            var roles = await _roleRepository.GetAll();
            return Ok(roles);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Role>> GetRole(int id)
        {
            var role = await _roleRepository.GetById(id);
            if (role == null)
            {
                return NotFound();
            }
            return Ok(role);
        }

        [HttpPost]
        public async Task<ActionResult<Role>> PostRole(RoleCreateDto request)
        {
            var role = new Role
            {
                Name = request.Name,
                TeamId = request.TeamId
            };

            await _roleRepository.Add(role);
            await _roleRepository.SaveChanges();

            return Ok(role);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutRole(int id, RoleUpdateDto request)
        {
            var existingRole = await _roleRepository.GetById(id);
            if (existingRole == null)
            {
                return NotFound();
            }

            existingRole.Name = request.Name;

            _roleRepository.Update(existingRole, id);
            await _roleRepository.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRole(int id)
        {
            var role = await _roleRepository.GetById(id);
            if (role == null)
            {
                return NotFound();
            }


            _roleRepository.Remove(id);
            await _roleRepository.SaveChanges();

            return NoContent();
        }
    }
}
