using Business.Model;

namespace Business.BusinessRepository.Interface
{
    public interface IStudentRepository
    {
        public Task<IEnumerable<Student>> ListStudents();
    }
}
