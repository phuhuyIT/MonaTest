using EmployeeManagement.Data;
using EmployeeManagement.DTO.EmployeeDTO;
using EmployeeManagement.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles ="Admin")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> AddEmployee(CreatedEmployeeDTO employee)
        {

            await _employeeService.AddEmployeeAsync(employee);
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees(int page = 1, int pageSize = 10, bool includeInactive = false)
        {
            var employees = await _employeeService.GetEmployeesAsync(page, pageSize, includeInactive);
            int total = await _employeeService.GetNumEmployeeAsync();
            var result = new
            {
                totalEmployee = total,
                data = employees,
                totalPage = (int)Math.Ceiling((double)total / pageSize)
            };
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(UpdateEmployeeDTO employeeDTO)
        {
            if (!await isExistsEmployee(employeeDTO.EmployeeId))
            {
                return NotFound();
            }
            await _employeeService.UpdateEmployeeAsync(employeeDTO);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            if ( !await isExistsEmployee(id)) 
            {
                return NotFound();
            }
            await _employeeService.DeleteEmployeeAsync(id);
            return NoContent();
        }
        [HttpDelete("softdelete/{id}")]
        public async Task<IActionResult> SoftDeleteEmployee(int id)
        {
            if (!await isExistsEmployee(id))
            {
                return NotFound();
            }
            await _employeeService.SoftDeleteEmployeeAsync(id);
            return NoContent();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployeeById(int id)
        {
            var employee = await _employeeService.GetEmployeeByIdAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            return employee;
        }
        private async Task<bool> isExistsEmployee(int id)
        {
            var employee = await _employeeService.GetEmployeeByIdAsync(id);
            return employee != null;
        }
    }
}
