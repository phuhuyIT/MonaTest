using EmployeeManagement.Data;
using EmployeeManagement.DTO.EmployeeDTO;

namespace EmployeeManagement.Service
{
    public interface IEmployeeService
    {
        Task<Employee> GetEmployeeByIdAsync(int id);
        Task<IEnumerable<Employee>> GetEmployeesAsync(int page, int pageSize, bool includeInactive);
        Task AddEmployeeAsync(CreatedEmployeeDTO employee);
        Task DeleteEmployeeAsync(int id);
        Task SoftDeleteEmployeeAsync(int id);
        Task UpdateEmployeeAsync(UpdateEmployeeDTO employeeDTO);
        Task<int> GetNumEmployeeAsync();
    }

}
