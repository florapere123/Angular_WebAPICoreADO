using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentsCoreApiAdo.Model;
using StudentsCoreApiAdo.Repository;
using StudentsCoreApiAdo.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using WebAPICoreADO.Enums;

namespace StudentsCoreApiAdo.Controllers
{
     [Route("api/Cities")]
    public class CitiesController : Controller
    {
        private readonly IOptions<MySettingsModel> appSettings;

        public CitiesController(IOptions<MySettingsModel> app)
        {
            appSettings = app;
        }

        [HttpGet]
        public  ActionResult<List<CityModel>> Get()
        {
            var data = DbClientFactory<CitiesDbClient>.Instance.GetCities(appSettings.Value.DbConn);
            return  data;
        }
        
    }
}