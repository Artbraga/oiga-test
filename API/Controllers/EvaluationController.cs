using Business.BusinessLogic.Interface;
using Business.Model;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class EvaluationController : Controller
    {
        private readonly IEvaluationService _evaluationService;

        public EvaluationController(IEvaluationService evaluationService)
        {
            _evaluationService = evaluationService;
        }

        [HttpGet("{courseId}/{studentId}")]
        public async Task<Evaluation> GetEvaluationByCourseAndStudent(string courseId, string studentId)
        {
            return await _evaluationService.GetEvaluationByCourseAndStudent(new Guid(courseId), new Guid(studentId));
        }

        [HttpGet("{courseId}")]
        public async Task<IEnumerable<EvaluationDTO>> GetEvaluationsByCourse(string courseId)
        {
            return await _evaluationService.GetEvaluationsByCourse(new Guid(courseId));
        }

        [HttpPost()]
        public async Task<bool> SaveEvaluation(EvaluationDTO evaluation)
        {
            return await _evaluationService.SaveEvaluation(evaluation);
        }

    }
}
