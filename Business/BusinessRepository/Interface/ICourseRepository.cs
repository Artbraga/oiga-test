using Business.Model;

namespace Business.BusinessRepository.Interface
{
    public interface ICourseRepository
    {
        public Task<IEnumerable<Course>> ListCourses();
        public Task<IEnumerable<Course>> ListCoursesByStudent(Guid studentId);

    }
}
