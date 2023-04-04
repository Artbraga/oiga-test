namespace Business.Model
{
    public class CourseStudent
    {
        public Guid Id { get; set; }
        public Guid CourseId { get; set; }
        public Guid StudentId { get; set; }
        public int Grade { get; set; }
        public virtual Course Course { get; set; }
        public virtual Student Student { get; set; }
        public virtual Evaluation Evaluation { get; set; }
    }
}
