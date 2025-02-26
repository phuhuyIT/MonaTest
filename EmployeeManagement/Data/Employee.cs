using System;
using System.Collections.Generic;

namespace EmployeeManagement.Data;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public string EmployeeCode { get; set; } = null!;

    public string Name { get; set; } = null!;

    public DateOnly DateOfBirth { get; set; }

    public string Position { get; set; } = null!;
    public int Age => DateTime.Now.Year - DateOfBirth.Year;
}
