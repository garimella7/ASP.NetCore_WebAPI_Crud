namespace EmployeesCrudAPI.Models
{
    public class AddEmployeeDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime DOB { get; set; }
        public decimal Salary { get; set; }
        public string Department { get; set; }
    }
}
