namespace TraningCenter.Models
{
    public class Student_Courses
    {
        public int Id { get; set; }
        public int Student_id { get; set; }
      
        public int Course_Id { get; set; }
        public Student student { get; set; }
        public Courses courses { get; set; }
    }
}
