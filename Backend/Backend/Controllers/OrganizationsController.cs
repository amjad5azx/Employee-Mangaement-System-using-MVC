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
    public class OrganizationsController : ControllerBase
    {
        private readonly IOrganizationRepository _organizationRepository;

        public OrganizationsController(IOrganizationRepository organizationRepository)
        {
            _organizationRepository = organizationRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Organization>>> GetOrganizations()
        {
            var organizations = await _organizationRepository.GetAll();
            return Ok(organizations);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Organization>> GetOrganization(int id)
        {
            var organization = await _organizationRepository.GetById(id);
            if (organization == null)
            {
                return NotFound();
            }
            return Ok(organization);
        }

        [HttpPost]
        public async Task<ActionResult<Organization>> PostOrganization(OrganizationCreateDto request)
        {
            var organization = new Organization
            {
                Name = request.Name,
                User_id = request.User_id  // Assuming User_id is provided in the request DTO
            };

            await _organizationRepository.Add(organization);
            await _organizationRepository.SaveChanges();

            return Ok(organization);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrganization(int id, OrganizationUpdateDto request)
        {
            var existingOrganization = await _organizationRepository.GetById(id);
            if (existingOrganization == null)
            {
                return NotFound();
            }

            existingOrganization.Name = request.Name;

            _organizationRepository.Update(existingOrganization, id);
            await _organizationRepository.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrganization(int id)
        {
            var organization = await _organizationRepository.GetById(id);
            if (organization == null)
            {
                return NotFound();
            }

            _organizationRepository.Remove(id);
            await _organizationRepository.SaveChanges();

            return NoContent();
        }
    }
}
