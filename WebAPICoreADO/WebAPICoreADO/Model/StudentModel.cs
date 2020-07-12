using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace StudentsCoreApiAdo.Model
{
   
    public class StudentModel:CityModel
    {
        public int ID { get; set; }

        public string FirstName { get; set; }
         public string LastName { get; set; }

        public DateTime? DateBirth { get; set; }

         public long  IsraeliID { get; set; } 
          
    }
}
