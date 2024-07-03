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
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentsController(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Department>>> GetDepartments()
        {
            var departments = await _departmentRepository.GetAll();
            return Ok(departments);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Department>> GetDepartment(int id)
        {
            var department = await _departmentRepository.GetById(id);
            if (department == null)
            {
                return NotFound();
            }
            return Ok(department);
        }

        [HttpPost]
        public async Task<ActionResult<Department>> PostDepartment(DepartmentCreateDto request)
        {
            var department = new Department
            {
                Name = request.Name,
                OrganizationId = request.OrganizationId
            };

            await _departmentRepository.Add(department);
            await _departmentRepository.SaveChanges();

            return Ok(department);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutDepartment(int id, DepartmentUpdateDto request)
        {
            var existingDepartment = await _departmentRepository.GetById(id);
            if (existingDepartment == null)
            {
                return NotFound();
            }

            existingDepartment.Name = request.Name;

            _departmentRepository.Update(existingDepartment, id);
            await _departmentRepository.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            var department = await _departmentRepository.GetById(id);
            if (department == null)
            {
                return NotFound();
            }

            _departmentRepository.Remove(id);
            await _departmentRepository.SaveChanges();

            return NoContent();
        }
    }
}
