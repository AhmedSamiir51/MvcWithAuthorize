using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcWithLogin.Models
{
    public class Stu_Courses
    {
        [Key]
        [Required]
        [ForeignKey("Student")]
        [Column(Order = 0)]
        public int St_id { get; set; }


        [Required]
        [Key]
        [ForeignKey("Courses")]
        [Column(Order = 1)]
        public int Courses_id { get; set; }

        [Range(1,200)]
        public int Grade { get; set; }


        public virtual Student Student { get; set; }
        public virtual Courses Courses { get; set; }
    }
}