using Business.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.BusinessRepository.Context
{
    public class CourseMapping : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            _ = builder.ToTable("Courses", "dbo");
            _ = builder.HasKey(entity => entity.Id);

            _ = builder.Property(r => r.Id)
                .HasColumnName("id")
                .HasColumnType("uniqueidentifier")
                .IsRequired();

            _ = builder.Property(entity => entity.Active)
                .HasColumnName("active")
                .HasColumnType("bit")
                .HasConversion<bool>();

            _ = builder.Property(entity => entity.Name)
                .HasColumnName("name")
                .HasColumnType("varchar(100)");

            _ = builder.Property(entity => entity.CreationDate)
                .HasColumnName("creation_date")
                .HasColumnType("date");
        }
    }

    public class StudentMapping : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            _ = builder.ToTable("Students", "dbo");
            _ = builder.HasKey(entity => entity.Id);

            _ = builder.Property(r => r.Id)
                .HasColumnName("id")
                .HasColumnType("uniqueidentifier")
                .IsRequired();

            _ = builder.Property(entity => entity.Active)
                .HasColumnName("active")
                .HasColumnType("bit")
                .HasConversion<bool>();

            _ = builder.Property(entity => entity.Name)
                .HasColumnName("name")
                .HasColumnType("varchar(100)");

            _ = builder.Property(entity => entity.LastName)
                .HasColumnName("last_name")
                .HasColumnType("varchar(100)");

            _ = builder.Property(entity => entity.CreationDate)
                .HasColumnName("creation_date")
                .HasColumnType("date");
        }
    }

    public class CourseStudentMapping : IEntityTypeConfiguration<CourseStudent>
    {
        public void Configure(EntityTypeBuilder<CourseStudent> builder)
        {
            _ = builder.ToTable("CourseStudents", "dbo");
            _ = builder.HasKey(entity => entity.Id);

            _ = builder.Property(r => r.Id)
                .HasColumnName("id")
                .HasColumnType("uniqueidentifier")
                .IsRequired();

            _ = builder.Property(r => r.CourseId)
                .HasColumnName("course_id")
                .HasColumnType("uniqueidentifier");

            _ = builder.Property(r => r.StudentId)
                .HasColumnName("student_id")
                .HasColumnType("uniqueidentifier");

            _ = builder.Property(entity => entity.Grade)
                .HasColumnName("grade")
                .HasColumnType("int");

            builder.HasOne(t => t.Course)
                .WithMany(c => c.CourseStudents)
                .HasForeignKey(t => t.CourseId);

            builder.HasOne(t => t.Student)
                .WithMany(c => c.CoursesStudent)
                .HasForeignKey(t => t.StudentId);
        }
    }


    public class EvaluationMapping : IEntityTypeConfiguration<Evaluation>
    {
        public void Configure(EntityTypeBuilder<Evaluation> builder)
        {
            _ = builder.ToTable("Evaluations", "dbo");
            _ = builder.HasKey(entity => entity.Id);

            _ = builder.Property(r => r.Id)
                .HasColumnName("id")
                .HasColumnType("uniqueidentifier")
                .IsRequired();

            _ = builder.Property(entity => entity.CourseStudentId)
                .HasColumnName("course_student_id")
                .HasColumnType("uniqueidentifier");

            _ = builder.Property(entity => entity.Stars)
                .HasColumnName("stars")
                .HasColumnType("int");

            _ = builder.Property(entity => entity.Description)
                .HasColumnName("description")
                .HasColumnType("varchar(MAX)");

            _ = builder.Property(entity => entity.CreationDate)
                .HasColumnName("creation_date")
                .HasColumnType("date");

            _ = builder.HasOne(entity => entity.CourseStudent)
                .WithOne(entity => entity.Evaluation);
        }
    }
}
