using EmployeeManagement.Data;
using EmployeeManagement.DTO.EmployeeDTO;

namespace EmployeeManagement.Service
{
    public interface IEmployeeService
    {
        Task<Employee> GetEmployeeByIdAsync(int id);
        Task<IEnumerable<Employee>> GetEmployeesAsync(int page, int pageSize);
        Task AddEmployeeAsync(CreatedEmployeeDTO employee);
        Task DeleteEmployeeAsync(int id);
        Task UpdateEmployeeAsync(UpdateEmployeeDTO employeeDTO);
        Task<int> GetNumEmployeeAsync();
    }

}
