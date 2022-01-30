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
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;

        BLLInterface bll;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
            bll = new BLL.BLL();
        }

        [HttpGet]
        public IEnumerable<UserModel> Get()
        {
            return bll.GetUsers();
        }

        [HttpGet("{userId}")]
        public UserModel GetById(int userId)
        {
            return bll.GetUsersInfo(userId);
        }

        [HttpGet("delete/{userId}")]
        public UserModel GetDeleteById(int userId)
        {
            UserModel model = bll.GetUsersInfo(userId);

            try
            {
                bll.GetUsersDelete(userId);

                return model;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return null;
        }

        [HttpPost("addUser")]
        public UserModel PostInsertUser(UserModel model)
        {
            if(bll.addUser(model))
            {
                return model;
            }

            return null;
        }

        [HttpPost("updateUser/{userId}")]
        public UserModel PostUpdatetUser(int userId, UserModel model)
        {
            try
            {
                bll.PostUserUpdate(userId, model);

                return model;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return null;
        }

        [HttpPost("login")]
        public UserModel Login(UserModel model)
        {
            try
            {
                UserModel user = bll.GetUser(model);

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
