using EmployeeManagement.Data;

namespace EmployeeManagement.Repository
{
    public interface IEmployeeRepo
    {
        Task<Employee> GetEmployeeByIdAsync(int id);
        Task<IEnumerable<Employee>> GetEmployeesAsync(int page, int pageSize);
        Task AddEmployeeAsync(Employee employee);
        Task UpdateEmployeeAsync(Employee employee);
        Task DeleteEmployeeAsync(int id);
    }
}
