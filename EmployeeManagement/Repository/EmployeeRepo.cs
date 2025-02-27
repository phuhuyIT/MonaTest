using EmployeeManagement.Data;
using EmployeeManagement.DTO.EmployeeDTO;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Repository
{
    public class EmployeeRepo : IEmployeeRepo { 
        private readonly MonaTestContext _context;

        public EmployeeRepo(MonaTestContext context)
        {
            _context = context;
        }

        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            return await _context.Employees.FindAsync(id);
        }

        public async Task<IEnumerable<Employee>> GetEmployeesAsync(int page, int pageSize)
        {
            return await _context.Employees
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task AddEmployeeAsync(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateEmployeeAsync(UpdateEmployeeDTO employeeDTO)
        {
            Employee employee = await GetEmployeeByIdAsync(employeeDTO.EmployeeId);
            employee.Name = employeeDTO.Name;
            employee.DateOfBirth = employeeDTO.DateOfBirth;
            employee.Position = employeeDTO.Position;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteEmployeeAsync(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<int> GetNumEmployeeAsync()
        {
            return await _context.Employees.CountAsync();
        }
    }

}
