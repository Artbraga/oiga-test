using Business.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.BusinessLogic.Interface
{
    public interface IEvaluationService
    {
        Task<Evaluation> GetEvaluationByCourseAndStudent(Guid courseId, Guid? studentId);
        Task<IEnumerable<EvaluationDTO>> GetEvaluationsByCourse(Guid courseId);
        Task<bool> SaveEvaluation(EvaluationDTO evaluation);
    }
}
