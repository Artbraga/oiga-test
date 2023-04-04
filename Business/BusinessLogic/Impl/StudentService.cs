using Business.BusinessLogic.Interface;
using Business.BusinessRepository.Interface;
using Business.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.BusinessLogic.Impl
{
    public class StudentService : IStudentService
    {
        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        private readonly IStudentRepository _studentRepository;

        public async Task<IEnumerable<Student>> ListStudents()
        {
            return await _studentRepository.ListStudents();
        }
    }
}
