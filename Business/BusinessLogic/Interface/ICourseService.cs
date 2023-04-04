using Business.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.BusinessLogic.Interface
{
    public interface ICourseService
    {
        public Task<IEnumerable<Course>> ListCourses();
        public Task<IEnumerable<Course>> ListCoursesByStudent(Guid studentId);
    }
}
