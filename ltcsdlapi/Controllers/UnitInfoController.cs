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
    public class UnitInfoController : ControllerBase
    {
        private readonly ILogger<UnitInfoController> _logger;

        BLLInterface bll;

        public UnitInfoController(ILogger<UnitInfoController> logger)
        {
            _logger = logger;
            bll = new BLL.BLL();
        }

        [HttpGet]
        public IEnumerable<UnitInfoModel> Get()
        {
            return bll.GetUnitInfo();
        }

        [HttpGet("{unitInfoId}")]
        public UnitInfoModel GetById(int unitInfoId)
        {
            return bll.GetUnitInfo_Info(unitInfoId);
        }

        [HttpGet("delete/{unitInfoId}")]
        public UnitInfoModel GetDeleteById(int unitInfoId)
        {
            UnitInfoModel model = bll.GetUnitInfo_Info(unitInfoId);

            try
            {
                bll.GetUnitInfoDelete(unitInfoId);

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
