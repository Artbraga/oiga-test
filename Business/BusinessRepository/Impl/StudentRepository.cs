using Business.BusinessRepository.Context;
using Business.BusinessRepository.Interface;
using Business.Model;
using Microsoft.EntityFrameworkCore;

namespace Business.BusinessRepository.Impl
{
    public class StudentRepository : IStudentRepository
    {
        private readonly Context.DbContext _context;
        public StudentRepository(Context.DbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Student>> ListStudents()
        {
            return await _context.Student.Where(x => x.Active).AsNoTracking().ToListAsync();
        }
    }
}
