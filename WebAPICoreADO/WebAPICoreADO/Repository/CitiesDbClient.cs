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
    public class CitiesDbClient
    {
        public List<CityModel> GetCities(string connString, int? CityID=null)
        {
            SqlParameter[] param = {
                new SqlParameter("@CityID",CityID)
            };
            return SqlHelper.ExtecuteProcedureReturnData<List<CityModel>>(connString,
                "GetCities",  r => r.MapAsCitiesList(),param);
        }

     
    }
}
