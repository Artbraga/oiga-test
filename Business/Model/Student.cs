namespace Business.Model
{
    public class Student
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime CreationDate { get; set; }
        public bool Active { get; set; }
        public virtual IEnumerable<CourseStudent> CoursesStudent { get; set; }
    }
}
