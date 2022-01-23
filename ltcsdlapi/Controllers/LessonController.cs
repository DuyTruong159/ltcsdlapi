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
    public class LessonController : ControllerBase
    {
        private readonly ILogger<LessonController> _logger;

        BLLInterface bll;

        public LessonController(ILogger<LessonController> logger)
        {
            _logger = logger;
            bll = new BLL.BLL();
        }

        [HttpGet]
        public IEnumerable<LessonModel> Get()
        {
            return bll.GetLessons();
        }

        [HttpGet("{lessonId}")]
        public LessonModel GetById(int lessonId)
        {
            return bll.GetLessonInfo(lessonId);
        }

        [HttpGet("delete/{lessonId}")]
        public LessonModel GetDeleteById(int lessonId)
        {
            LessonModel model = bll.GetLessonInfo(lessonId);

            try
            {
                bll.GetLessonsDelete(lessonId);

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
