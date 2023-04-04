using Business.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Business.BusinessRepository.Context
{
    public class DbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbContext(DbContextOptions<DbContext> options) : base(options)
        {
        }

        public virtual DbSet<Course> Course { get; set; }
        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<Evaluation> Evaluations { get; set; }
        public virtual DbSet<CourseStudent> CourseStudent { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            _ = modelBuilder.ApplyConfiguration(new CourseMapping());
            _ = modelBuilder.ApplyConfiguration(new EvaluationMapping());
            _ = modelBuilder.ApplyConfiguration(new StudentMapping());
            _ = modelBuilder.ApplyConfiguration(new CourseStudentMapping());
        }
    }
}
