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
     [Route("api/[controller]")]
    [ApiController]  
    public class StudentController : ControllerBase
    {
        private readonly IOptions<MySettingsModel> appSettings;
        
        public StudentController(IOptions<MySettingsModel> app)
        {
            appSettings = app;
        }

        [HttpGet]
        public  ActionResult<List<StudentModel>> Get()
        {
            var data = DbClientFactory<StudentDbClient>.Instance.GetStudents(appSettings.Value.DbConn);
            return  data;
        }
        
        [HttpGet("{id}")]
        public ActionResult<StudentModel> Get(int id)
        {
            StudentModel student = new StudentModel();
            var data = DbClientFactory<StudentDbClient>.Instance.GetStudents(appSettings.Value.DbConn,id);
             
            return  data.Any()? data.FirstOrDefault() : null ;
        }
        [HttpPost]
        public ActionResult<Message<StudentModel>> Post([FromBody]StudentModel model)
        {
            return SaveStudent(model) ;
        }
        [HttpPut("{id:int}")]
        public ActionResult<Message<StudentModel>> Put([FromBody]StudentModel model)
        {
            return SaveStudent(model);
        }

        private ActionResult<Message<StudentModel>> SaveStudent(StudentModel model)
        {
            var msg = new Message<StudentModel>();
            try
            {
                var data = DbClientFactory<StudentDbClient>.Instance.SaveStudent(model, appSettings.Value.DbConn);
                if (data.Item2 == (Int32)ErrorCodes.ERR_SUCCESS)
                {
                    msg.IsSuccess = true;
                    if (model.ID == 0)
                        msg.ReturnMessage = "Student saved successfully for ID: " + data.Item1.ID;
                    else
                        msg.ReturnMessage = "Student updated successfully";
                }
                else if (data.Item2 == (Int32)ErrorCodes.ERR_ISRAELIID_EXISTS)
                {
                    msg.IsSuccess = false;
                    msg.ReturnMessage = EnumHelper<ErrorCodes>.GetEnumDescription(ErrorCodes.ERR_ISRAELIID_EXISTS.ToString());

                }
                msg.Data = data.Item1;
            }
            catch(Exception ex)
            {
                msg.IsSuccess = false;
                msg.ReturnMessage = ex.Message;

            }
            return msg;
        }
    }
}