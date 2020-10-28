using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api.Models
{
    public class ResultObject
    {
        /*
        class to display the result after requesting 
        */
        public String Code { get; set; }
        public String Message { get; set; }
        public Object Data { get; set; }
    }
}