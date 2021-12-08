
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TraningCenter.Models
{
    public class Student
    {
        [Key]
        public int Student_id { get; set; }
        public string Student_Name { get; set; }
        public virtual ICollection<Student_Courses> Student_s { get; set; }
    }
}
