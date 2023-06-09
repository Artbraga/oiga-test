﻿namespace Business.Model
{
    public class Evaluation
    {
        public Guid Id { get; set; }
        public Guid CourseStudentId { get; set; }
        public int Stars { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public virtual CourseStudent CourseStudent { get; set; }
    }
}
