using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcWithLogin.Models
{
    public class Student
    {
        [Required]
        [Key]
        public int ID { get; set; }


        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        public string Name { get; set; }


        [Range(10,100)]
        public int Age { get; set; }


        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }


        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }


        [NotMapped]
    
        public string ConfirmPassword { get; set; }


        [ForeignKey("Department")]
        public int Dept_id { get; set; }

        public virtual Department Department { get; set; }
        public virtual List<Stu_Courses> Stu_Courses { get; set; }

    }
}