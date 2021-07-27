using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcWithLogin.Models
{
    public class Department
    {
        [Required]
        [Key]
        public int ID { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        public string Name { get; set; }
        [Required]
        public string Location { get; set; }

        public virtual List<Student> Students { get; set; }


    }
}