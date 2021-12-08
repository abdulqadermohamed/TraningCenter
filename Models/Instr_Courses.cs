namespace TraningCenter.Models
{
    public class Instr_Courses
    {
        public int Id { get; set; }
        public int Instractor_Id { get; set; }
     
        public int Course_Id { get; set; }
        public Instractor Instractor { get; set; }
        public Courses courses { get; set; }
    }
}
