namespace EmployeesCrudAPI.Models.Domain
{
    public class Employee
    {
        public Guid ID { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public DateTime DOB { get; set; }
        public decimal Salary { get; set; }
        public string Department { get; set; }
    }
}
