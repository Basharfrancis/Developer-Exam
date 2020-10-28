using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api.Exceptions
{
    public class BusinessException : Exception
    {
        public Errors.Codes Code { get; set; }
        BusinessException() : base() { }
        public BusinessException(Errors.Codes code) : base(Errors.GetErrorMessage(code.ToString()))
        {
            this.Code = code;
        }
    }
}