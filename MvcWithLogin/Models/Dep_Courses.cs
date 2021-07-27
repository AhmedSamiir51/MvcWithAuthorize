using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcWithLogin.Models
{
    public class Dep_Courses
    {
        [Key]
        [ForeignKey("Department")]
        [Column(Order =0)]
        public int Dep_id { get; set; }


        [Key]
        [ForeignKey("Courses")]
        [Column(Order = 1)]
        public int Courses_id { get; set; }


        public virtual Courses Courses { get; set; }

        public virtual Department Department { get; set; }
    }
}