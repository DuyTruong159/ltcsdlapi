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
    public class UnitController : ControllerBase
    {
        private readonly ILogger<UnitController> _logger;

        BLLInterface bll;

        public UnitController(ILogger<UnitController> logger)
        {
            _logger = logger;
            bll = new BLL.BLL();
        }

        [HttpGet]
        public IEnumerable<UnitModel> Get()
        {
            return bll.GetUnit();
        }

        [HttpGet("{unitId}")]
        public UnitModel GetById(int unitId)
        {
            return bll.GetUnitsInfo(unitId);
        }

        [HttpGet("delete/{unitId}")]
        public UnitModel GetDeleteById(int unitId)
        {
            UnitModel model = bll.GetUnitsInfo(unitId);

            try
            {
                bll.GetUnitsDelete(unitId);

                return model;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return null;
        }

        [HttpPost("addUnit")]
        public UnitModel PostInsertUnit(UnitModel model)
        {
            try
            {
                bll.postUnitInsert(model);

                return model;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return null;
        }

        [HttpPost("updateUnit/{unitId}")]
        public UnitModel PostUpdatetCourse(int unitId, UnitModel model)
        {
            try
            {
                bll.postUnitUpdate(unitId, model);

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
