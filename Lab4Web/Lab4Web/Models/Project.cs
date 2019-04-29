
using System.ComponentModel.DataAnnotations;

namespace lab4Web.Models
{
    public class Project
    {
        public int Id { get; set; }

        [Required]
        public int EmployeeId { get; set; }
        
        [Required]
        public string Name { get; set; }
        
        [Required]
        public int Award { get; set; }
        
        public virtual Employee Employee { get; set; }

    }
}