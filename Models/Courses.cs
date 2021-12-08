using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TraningCenter.Models
{
    public class Courses
    {
        [Key]
        public int Course_Id { get; set; }
        public string Course_name { get; set; }
        public virtual ICollection<Student_Courses> _Courses { get; set; }
        public virtual ICollection<Instr_Courses> CoursesInstr { get; set; }


    }
}
