using Business.BusinessLogic.Interface;
using Business.BusinessRepository.Interface;
using Business.Model;
using System.Security.Cryptography.X509Certificates;

namespace Business.BusinessLogic.Impl
{
    public class EvaluationService : IEvaluationService
    {
        private readonly IEvaluationRepository _evaluationRepository;
        private readonly ICourseStudentRepository _courseStudentRepository;

        public EvaluationService(IEvaluationRepository evaluationRepository, ICourseStudentRepository courseStudentRepository)
        {
            _evaluationRepository = evaluationRepository;
            _courseStudentRepository = courseStudentRepository;
        }

        public async Task<Evaluation> GetEvaluationByCourseAndStudent(Guid courseId, Guid? studentId)
        {
            return await _evaluationRepository.GetEvaluationByCourseAndStudent(courseId, studentId);
        }

        public async Task<IEnumerable<EvaluationDTO>> GetEvaluationsByCourse(Guid courseId)
        {
            IEnumerable<Evaluation> evaluations = await _evaluationRepository.GetEvaluationsByCourse(courseId);
            return evaluations.Select(x => new EvaluationDTO()
            {
                StudentName = $"{x.CourseStudent.Student.Name} {x.CourseStudent.Student.LastName}",
                Stars = x.Stars,
                Description = x.Description
            });
        }

        public async Task<bool> SaveEvaluation(EvaluationDTO evaluation)
        {
            Evaluation? evaluationSaved = await _evaluationRepository.GetEvaluationByCourseAndStudent(new Guid(evaluation.CourseId), new Guid(evaluation.StudentId));
            Evaluation newEvaluation;
            CourseStudent courseStudent = await _courseStudentRepository.GetRelationshipByCourseAndStudent(new Guid(evaluation.CourseId), new Guid(evaluation.StudentId));
            try
            {
                if (evaluationSaved == null)
                {
                    newEvaluation = new Evaluation()
                    {
                        CourseStudentId = courseStudent.Id,
                        CreationDate = DateTime.Now,
                        Stars = evaluation.Stars,
                        Description = evaluation.Description
                    };
                    await _evaluationRepository.Save(newEvaluation);
                }
                else
                {
                    evaluationSaved.Stars = evaluation.Stars;
                    evaluationSaved.Description = evaluation.Description;
                    evaluationSaved.CreationDate = DateTime.Now;
                    await _evaluationRepository.Update(evaluationSaved);
                }
                await _evaluationRepository.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
