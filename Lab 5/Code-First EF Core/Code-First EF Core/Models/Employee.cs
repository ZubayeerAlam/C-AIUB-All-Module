using System.ComponentModel.DataAnnotations;

namespace Code_First_EF_Core.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "Employee name is required")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 100 characters")] 
        public string FullName { get; set; }

        [Required(ErrorMessage = "Designation is required")]
        [StringLength(50, ErrorMessage = "Designation cannot exceed 50 characters")]
        public string Designation { get; set; }

        [Required(ErrorMessage = "Salary is required")]
        [Range(10000, 500000, ErrorMessage = "Salary must be between 10,000 and 500,000")]
        public decimal Salary { get; set; }

        // Foreign key 
        [Required(ErrorMessage = "Please select a department")]
        public int DepartmentId { get; set; }

        // Navigation property 
        public virtual Department Department { get; set; }
    }
}
