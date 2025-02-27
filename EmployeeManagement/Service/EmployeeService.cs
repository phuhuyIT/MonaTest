using EmployeeManagement.Data;
using EmployeeManagement.DTO.EmployeeDTO;
using EmployeeManagement.Repository;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepo _employeeRepo;

        public EmployeeService(IEmployeeRepo employeeRepo)
        {
            _employeeRepo = employeeRepo;
        }

        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            return await _employeeRepo.GetEmployeeByIdAsync(id);
        }

        public async Task<IEnumerable<Employee>> GetEmployeesAsync(int page, int pageSize)
        {
            if (!await CheckPageAndPageSize(page, pageSize))
            {
                return null;
            }
            return await _employeeRepo.GetEmployeesAsync(page, pageSize);
        }

        public async Task AddEmployeeAsync(CreatedEmployeeDTO employeeDTO)
        {
            var employee = new Employee
            {
                EmployeeCode = $"NV_{DateTime.Now:yyyy_MM_dd}_{ await _employeeRepo.GetNumEmployeeAsync()+ 1}",
                Name = employeeDTO.Name,
                DateOfBirth = employeeDTO.DateOfBirth,
                Position = employeeDTO.Position
            };
            await _employeeRepo.AddEmployeeAsync(employee);
        }

        public async Task UpdateEmployeeAsync(UpdateEmployeeDTO employeeDTO)
        {
            await _employeeRepo.UpdateEmployeeAsync(employeeDTO);
        }

        public async Task DeleteEmployeeAsync(int id)
        {

            await _employeeRepo.DeleteEmployeeAsync(id);
        }

        private async Task<bool> CheckPageAndPageSize(int page, int pageSize)
        {
            int num = await _employeeRepo.GetNumEmployeeAsync();

            if (page < 1 || pageSize < 1)
            {
                return false;
            }

            if (page * pageSize > num + pageSize)
            {
                return false;
            }
            return true;
        }

        public async Task<int> GetNumEmployeeAsync()
        {
            return await _employeeRepo.GetNumEmployeeAsync();
        }
    }

}
