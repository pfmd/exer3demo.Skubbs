using Exer3.Api.Data;
using Exer3.Api.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Exer3.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("MyPolicy")]
    public class EmployeesController : ControllerBase
    {
        private readonly EmployeeDbContext _context;
        public EmployeesController(EmployeeDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllEmployee() {
            var employees = _context.Employees.ToList();
            return Ok(employees);
        }

        [HttpGet("{id}")]
        [EnableCors("MyPolicy")]
        public IActionResult GetEmployeeById(int id)
        {
            try
            {
                var result = _context.Employees.Find(id);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception )
            {
                return StatusCode(500);
            }
         
           
            
        }

        [HttpPut("{id}")]
        [EnableCors("MyPolicy")]
        public IActionResult UpdateEmployee(int id,Employee employee)
        {
            try
            {
                var result = _context.Employees.Find(id);
                if (result == null)
                {
                    return NotFound();
                }
                result.FirstName = employee.FirstName;
                result.LastName = employee.LastName;
                result.DateOfBirth = employee.DateOfBirth;
                _context.Update(result);
                _context.SaveChanges();
                return Ok(result);
            }
            catch (Exception )
            {
                return StatusCode(500);
            }
           
        }
        [HttpPost]
        public IActionResult CreateEmployee(Employee employee)
        {
            try
            {
                _context.Employees.Add(employee);
                _context.SaveChanges();
                return CreatedAtAction(nameof(GetAllEmployee), employee);
            }
            catch (Exception )
            {
                return StatusCode(500);
            }


        }


    }
}
