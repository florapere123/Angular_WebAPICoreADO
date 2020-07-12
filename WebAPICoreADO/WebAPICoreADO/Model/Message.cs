using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace StudentsCoreApiAdo.Model
{
    [DataContract]
    public class Message<T>
    {
        
        public bool IsSuccess { get; set; }
         
        public int StatusCode { get; set; }

       
        public string ReturnMessage { get; set; }

        
        public T Data { get; set; }
    }

}
