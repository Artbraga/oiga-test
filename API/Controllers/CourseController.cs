using Business.BusinessLogic.Impl;
using Business.BusinessLogic.Interface;
using Business.Model;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class CourseController : Controller
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet()]
        public async Task<IEnumerable<Course>> ListCourses()
        {
            return await _courseService.ListCourses();
        }

        [HttpGet("{studentId}")]
        public async Task<IEnumerable<Course>> ListCoursesByStudent(string studentId)
        {
            return await _courseService.ListCoursesByStudent(new Guid(studentId));
        }

    }
}
