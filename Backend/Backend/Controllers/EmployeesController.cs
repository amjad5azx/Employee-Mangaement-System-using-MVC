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
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeesController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            var employees = await _employeeRepository.GetAll();
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            var employee = await _employeeRepository.GetById(id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee(EmployeeCreateDto request)
        {
            var employee = new Employee
            {
                EmployeeName = request.EmployeeName,
                RoleId = request.RoleId,
                TeamId = request.TeamId
            };

            await _employeeRepository.Add(employee);
            await _employeeRepository.SaveChanges();

            return Ok(employee);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(int id, EmployeeUpdateDto request)
        {
            var existingEmployee = await _employeeRepository.GetById(id);
            if (existingEmployee == null)
            {
                return NotFound();
            }

            existingEmployee.EmployeeName = request.EmployeeName;
            existingEmployee.RoleId = request.RoleId;
            existingEmployee.TeamId = request.TeamId;

            _employeeRepository.Update(existingEmployee, id);
            await _employeeRepository.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var employee = await _employeeRepository.GetById(id);
            if (employee == null)
            {
                return NotFound();
            }

            _employeeRepository.Remove(id);
            await _employeeRepository.SaveChanges();

            return NoContent();
        }
    }
}
