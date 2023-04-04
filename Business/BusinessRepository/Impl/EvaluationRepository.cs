using Business.BusinessRepository.Interface;
using Business.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.BusinessRepository.Impl
{
    public class EvaluationRepository : IEvaluationRepository
    {
        private readonly Context.DbContext _context;

        public EvaluationRepository(Context.DbContext context)
        {
            _context = context;
        }

        public async Task<Evaluation?> GetEvaluationByCourseAndStudent(Guid courseId, Guid? studentId)
        {
            return await _context.Evaluations
                .Include(x => x.CourseStudent)
                .Where(x => x.CourseStudent.CourseId == courseId && (studentId == null ||x.CourseStudent.StudentId == studentId))
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Evaluation>> GetEvaluationsByCourse(Guid courseId)
        {
            return await _context.Evaluations
                .Include(x => x.CourseStudent)
                .ThenInclude(x => x.Student)
                .Where(x => x.CourseStudent.CourseId == courseId)
                .OrderByDescending(x => x.CreationDate)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task Save(Evaluation evaluation)
        {
            await _context.Evaluations.AddAsync(evaluation);
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }

        public async Task Update(Evaluation evaluation)
        {
            _context.Entry(evaluation).State = EntityState.Modified;
        }
    }
}
