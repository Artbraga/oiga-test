using Business.Model;

namespace Business.BusinessLogic.Interface
{
    public interface IStudentService
    {
        public Task<IEnumerable<Student>> ListStudents();
    }
}
