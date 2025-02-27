namespace EmployeeManagement.DTO.EmployeeDTO
{
    public class UpdateEmployeeDTO
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string Position { get; set; }
    }
}
