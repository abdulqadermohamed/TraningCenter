using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TraningCenter.Models
{
    public class Instractor
    {
        [Key]
        public int Instractor_Id { get; set; }
        public string Instractor_Name { get; set; }
        public virtual ICollection<Instr_Courses> instrcors { get; set; }

    }
}
