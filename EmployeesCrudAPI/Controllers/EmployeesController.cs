using EmployeesCrudAPI.Data;
using EmployeesCrudAPI.Models;
using EmployeesCrudAPI.Models.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeesCrudAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly EmployeeDBContext dbContext;
        public EmployeesController(EmployeeDBContext _dbContext)
        {
            dbContext = _dbContext;
        }

        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            var employeesList = dbContext.Employees.ToList();
            return Ok(employeesList);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetEmployeebyId(Guid id)
        {
            var employee = dbContext.Employees.Find(id);

            if(employee is null)
            {
                return NotFound();
            }
            
            return Ok(employee);            
        }

        [HttpPost]
        public IActionResult AddEmployee(AddEmployeeDTO addEmployeeDTO)
        {
            var employee = new Employee()
            {
                Email = addEmployeeDTO.Email,
                Name = addEmployeeDTO.Name,
                Department = addEmployeeDTO.Department,
                DOB = addEmployeeDTO.DOB,
                Salary = addEmployeeDTO.Salary
            };

            dbContext.Employees.Add(employee);
            dbContext.SaveChanges();

            return Ok(employee);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult UpdateEmployee(Guid id, UpdateEmployeeDTO updateEmployeeDTO)
        {
            var employee = dbContext.Employees.Find(id);

            if(employee is null)
            {
                return NotFound();
            }

            employee.Name = updateEmployeeDTO.Name;
            employee.Salary = updateEmployeeDTO.Salary;
            employee.Email = updateEmployeeDTO.Email;
            employee.Department = updateEmployeeDTO.Department;

            dbContext.SaveChanges();

            return Ok(employee);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeleteEmployee(Guid id)
        {
            var employee = dbContext.Employees.Find(id);

            if(employee is null)
            {
                return NotFound();
            }

            dbContext.Employees.Remove(employee);
            dbContext.SaveChanges();

            return Ok();
        }
    }
}
