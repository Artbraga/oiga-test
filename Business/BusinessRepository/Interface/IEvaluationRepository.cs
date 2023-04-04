using Business.Model;

namespace Business.BusinessRepository.Interface
{
    public interface IEvaluationRepository
    {
        Task<Evaluation?> GetEvaluationByCourseAndStudent(Guid courseId, Guid? studentId);
        Task<IEnumerable<Evaluation>> GetEvaluationsByCourse(Guid courseId);
        Task Save(Evaluation evaluation);
        Task SaveChanges();
        Task Update(Evaluation evaluation);
    }
}
