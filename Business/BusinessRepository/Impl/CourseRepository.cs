using Business.BusinessRepository.Context;
using Business.BusinessRepository.Interface;
using Business.Model;
using Microsoft.EntityFrameworkCore;

namespace Business.BusinessRepository.Impl
{
    public class CourseRepository : ICourseRepository
    {
        private readonly Context.DbContext _context;

        public CourseRepository(Context.DbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Course>> ListCourses()
        {
            return await _context.Course
                .Include(x => x.CourseStudents)
                .Where(x => x.Active)
                .AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<Course>> ListCoursesByStudent(Guid studentId)
        {
            return await _context.Course
                .Include(x => x.CourseStudents)
                .Where(x => x.Active && x.CourseStudents.Any(cs => cs.StudentId == studentId))
                .AsNoTracking().ToListAsync();
        }
    }
}
