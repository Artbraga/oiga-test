using Business.BusinessRepository.Interface;
using Business.Model;
using Microsoft.EntityFrameworkCore;

namespace Business.BusinessRepository.Impl
{
    public class CourseStudentRepository : ICourseStudentRepository
    {
        private readonly Context.DbContext _context;

        public CourseStudentRepository(Context.DbContext context)
        {
            _context = context;
        }

        public async Task<CourseStudent?> GetRelationshipByCourseAndStudent(Guid courseId, Guid studentId)
        {
            return await _context.CourseStudent
                .Where(x => x.CourseId == courseId && x.StudentId == studentId)
                .AsNoTracking().FirstOrDefaultAsync();
        }
    }
}
