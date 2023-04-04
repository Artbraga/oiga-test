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
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;

        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public Task<IEnumerable<Course>> ListCourses()
        {
            return _courseRepository.ListCourses();
        }

        public Task<IEnumerable<Course>> ListCoursesByStudent(Guid studentId)
        {
            return _courseRepository.ListCoursesByStudent(studentId);
        }
    }
}
