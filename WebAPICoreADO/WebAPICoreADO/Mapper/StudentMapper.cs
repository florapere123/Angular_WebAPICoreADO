using StudentsCoreApiAdo.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using StudentsCoreApiAdo.Utility;

namespace StudentsCoreApiAdo.Mapper
{
    public static class StudentMapper
    {
        public static StudentModel MapAsStudent(this SqlDataReader reader,bool isList = false)
        {
            if(!isList)
            {
                if (!reader.HasRows)
                    return null;
                reader.Read();
            }
            var item = new StudentModel();
            if (reader.IsColumnExists("ID"))
                item.ID = SqlHelper.GetNotNullableInt32(reader, "ID");

            if (reader.IsColumnExists("FirstName"))
                item.FirstName = SqlHelper.GetNullableString(reader, "FirstName");

            if (reader.IsColumnExists("LastName"))
                item.LastName = SqlHelper.GetNullableString(reader, "LastName");
            if (reader.IsColumnExists("DateBirth"))
                item.DateBirth = SqlHelper.GetDateTime(reader, "DateBirth");

            if (reader.IsColumnExists("IsraeliID"))
                item.IsraeliID = SqlHelper.GetNotNullableInt64(reader, "IsraeliID");
            if (reader.IsColumnExists("CityID"))
                item.CityID = SqlHelper.GetNotNullableInt32(reader, "CityID");

            if (reader.IsColumnExists("CityName"))
                item.CityName = SqlHelper.GetNullableString(reader, "CityName");
            return item;
        }

        public static List<StudentModel> MapAsStudentsList(this SqlDataReader reader)
        {
            var list = new List<StudentModel>();
            while(reader.Read())
            {
                list.Add(MapAsStudent(reader, true));
            }
            return list;
        }
       
    }
}
