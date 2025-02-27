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

        public async Task<IEnumerable<Employee>> GetEmployeesAsync(int page, int pageSize, bool includeInactive)
        {
            var query = _context.Employees.AsQueryable();
            if (!includeInactive)
            {
                query = query.Where(e => e.IsActive);
            }
            var employees = await query
                          .Skip((page - 1) * pageSize)
                          .Take(pageSize)
                          .ToListAsync();
            return employees;
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

        public async Task SoftDeleteEmployeeAsync(int id)
        {
            var employee = _context.Employees.Find(id);
            employee.IsActive = false;
            employee.DateOfLeaving = DateTime.Now;
            await _context.SaveChangesAsync();
        }
    }

}
