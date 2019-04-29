
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace lab4Web.Models
{
    public class Employee
    {

        public Employee()
        {
            Projects = new HashSet<Project>();
        }
        
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }
        
        [Required]
        public string Surname { get; set; }
        
        [Required]
        public  string Patronymic { get; set; }
        
        [Required]
        public string City { get; set; }
        
        public virtual ICollection<Project> Projects { get; set; }
    }
}