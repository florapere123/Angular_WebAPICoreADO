using StudentsCoreApiAdo.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using StudentsCoreApiAdo.Utility;

namespace StudentsCoreApiAdo.Mapper
{
    public static class CityMapper
    {
        public static CityModel MapAsCity(this SqlDataReader reader,bool isList = false)
        {
            if(!isList)
            {
                if (!reader.HasRows)
                    return null;
                reader.Read();
            }
            var item = new CityModel();
            if (reader.IsColumnExists("CityID"))
                item.CityID = SqlHelper.GetNotNullableInt32(reader, "CityID");

            if (reader.IsColumnExists("CityName"))
                item.CityName = SqlHelper.GetNullableString(reader, "CityName");
             
            return item;
        }
        public static List<CityModel> MapAsCitiesList(this SqlDataReader reader)
        {
            var list = new List<CityModel>();
            while (reader.Read())
            {
                list.Add(MapAsCity(reader, true));
            }
            return list;
        }

    }
}
