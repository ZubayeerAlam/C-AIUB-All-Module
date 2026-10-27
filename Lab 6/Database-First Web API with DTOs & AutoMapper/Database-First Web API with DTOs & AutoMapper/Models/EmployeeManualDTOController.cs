using CompanyWebAPI.DTOs;
using Database_First_Web_API_with_DTOs___AutoMapper.DTOS;
using Microsoft.AspNetCore.Mvc;

namespace Database_First_Web_API_with_DTOs___AutoMapper.Models
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeManualDTOController : ControllerBase
    {
        private readonly CompanyApiDbContext _context;

        public EmployeeManualDTOController(CompanyApiDbContext context)
        {
            _context = context;
        }
        // GET: api/EmployeeManualDTO 
        [HttpGet]
        public IActionResult GetAll()
        {
            var dtos = _context.Employees
                .Include(e => e.Department)
                .Select(e => new EmployeeDTO
                {
                    EmployeeId = e.EmployeeId,
                    FullName = e.FullName,
                    Designation = e.Designation,
                    Salary = e.Salary,
                    DepartmentId = e.DepartmentId,
                    DepartmentName = e.Department.DepartmentName
                }).ToList();

            return Ok(dtos);
        }

        // POST: api/EmployeeManualDTO/Save 
        [HttpPost("Save")]
        public IActionResult Save([FromBody] EmployeeSaveDTO dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var emp = new Employee
            {
                EmployeeId = dto.EmployeeId,
                FullName = dto.FullName,
                Designation = dto.Designation,
                Salary = dto.Salary,
                DepartmentId = dto.DepartmentId,
                UpdatedAt = DateTime.UtcNow
            };
            if (!_context.Employees.Any(e => e.EmployeeId == emp.EmployeeId))
            {
                // New record 
                _context.Employees.Add(emp);
            }
            else
            {
                // Update existing record 
                _context.Employees.Update(emp);
            }
            _context.SaveChanges();
            return Ok(new { message = "Saved via manual DTO mapping.", data = emp });
        }
    }
}
