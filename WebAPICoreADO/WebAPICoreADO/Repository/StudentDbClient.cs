using StudentsCoreApiAdo.Model;
using StudentsCoreApiAdo.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentsCoreApiAdo.Mapper;
using System.Data.SqlClient;
using System.Data;

namespace StudentsCoreApiAdo.Repository
{
    public class StudentDbClient
    {
        public List<StudentModel> GetStudents(string connString, int? ID=null)
        {
            SqlParameter[] param = {
                new SqlParameter("@ID",ID)
            };
            return SqlHelper.ExtecuteProcedureReturnData<List<StudentModel>>(connString,
                "GetStudents",  r => r.MapAsStudentsList(),param);
        }

        public Tuple<StudentModel,Int32> SaveStudent(StudentModel model, string connString)
        {
            var outParam = new SqlParameter("@ReturnCode", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };
            SqlParameter[] param = {
                new SqlParameter("@ID",model.ID),
                new SqlParameter("@FirstName",model.FirstName),
                new SqlParameter("@LastName",model.LastName),
                new SqlParameter("@DateBirth",model.DateBirth),
                new SqlParameter("@IsraeliID",model.IsraeliID),
                new SqlParameter("@CityID",model.CityID),
                outParam
            };
            var updatedStudent= SqlHelper.ExtecuteProcedureReturnData<StudentModel>(connString, "SaveStudent", r => r.MapAsStudent(), param);
            return new Tuple<StudentModel, int>(updatedStudent, (Int32)outParam.Value);
        }

       
    }
}
