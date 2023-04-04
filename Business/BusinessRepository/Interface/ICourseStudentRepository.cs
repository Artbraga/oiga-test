using Business.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.BusinessRepository.Interface
{
    public interface ICourseStudentRepository
    {
        Task<CourseStudent?> GetRelationshipByCourseAndStudent(Guid courseId, Guid studentId);
    }
}
