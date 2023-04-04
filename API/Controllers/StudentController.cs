using Business.BusinessLogic.Interface;
using Business.Model;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet()]
        public async Task<IEnumerable<Student>> ListStudents()
        {
            return await _studentService.ListStudents();
        }

    }
}
