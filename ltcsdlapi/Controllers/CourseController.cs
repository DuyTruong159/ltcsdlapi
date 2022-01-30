using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ltcsdlapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CourseController : ControllerBase
    {
        private readonly ILogger<CourseController> _logger;

        BLLInterface bll;

        public CourseController(ILogger<CourseController> logger)
        {
            _logger = logger;
            bll = new BLL.BLL();
        }

        [HttpGet]
        public IEnumerable<CourseModel> Get()
        {
            return bll.getCourse();
        }

        [HttpGet("{courseId}")]
        public CourseModel GetById(int courseId)
        {
            return bll.GetCourseInfo(courseId);
        }
         
        [HttpGet("delete/{courseId}")]
        public CourseModel GetDeleteById(int courseId)
        {
            CourseModel model = bll.GetCourseInfo(courseId);

            try
            {
                bll.getCourseDelete(courseId);

                return model;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return null;
        }

        [HttpPost("addCourse")]
        public CourseModel PostInsertCourse(CourseModel model)
        {
            try
            {
                bll.postCourseInsert(model);

                return model;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return null;
        }

        [HttpPost("updateCourse/{courseId}")]
        public CourseModel PostUpdatetCourse(int courseId, CourseModel model)
        {
            try
            {
                bll.PostCourseUpdate(courseId, model);

                return model;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return null;
        }
    }
}
