using System.ComponentModel.DataAnnotations;

namespace Code_First_EF_Core.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }

        [Required(ErrorMessage = "Department Name is required")]
        [StringLength(100)]
        public string DepartmentName { get; set; }

        // Navigation property — One Department has many Employees 
        public virtual List<Employee> Employees { get; set; }
    }
}
