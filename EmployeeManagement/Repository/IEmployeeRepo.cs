﻿using EmployeeManagement.Data;
using EmployeeManagement.DTO.EmployeeDTO;

namespace EmployeeManagement.Repository
{
    public interface IEmployeeRepo
    {
        Task<Employee> GetEmployeeByIdAsync(int id);
        Task<IEnumerable<Employee>> GetEmployeesAsync(int page, int pageSize);
        Task AddEmployeeAsync(Employee employee);
        Task UpdateEmployeeAsync(UpdateEmployeeDTO employee);
        Task DeleteEmployeeAsync(int id);
        Task<int> GetNumEmployeeAsync();
    }
}
