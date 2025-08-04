using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace webAPI;
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
public class CourseController  : ControllerBase

{
        private  CourseService courseService;

        public CourseController()
        {
            courseService = new CourseService();
        }

        [HttpGet]
        public IActionResult GetCourses()
        {
            return Ok(courseService.GetCourses());
        }


        [HttpGet("{id}")]
        public IActionResult GetCourse(string id)
        {
            return Ok(courseService.GetCourse(id));
        }

        
    }


