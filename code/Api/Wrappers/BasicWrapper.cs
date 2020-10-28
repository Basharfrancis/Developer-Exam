using Api.Exceptions;
using Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api.Wrappers
{
    public class BasicWrapper
    {
        public static ResultObject SuccessResult(Object obj)
        {
            ResultObject result = new ResultObject()
            {
                Code = ((int)Errors.Codes.Success) + "",
                Data = obj,
                Message = Errors.GetErrorMessage(Errors.Codes.Success.ToString())
            };
            return result;
        }
        public static ResultObject ErrorResult(Errors.Codes errCode, String message)
        {
            ResultObject result = new ResultObject()
            {
                Code = ((int)errCode) + "",
                Data = new object(),
                Message = message
            };
            return result;
        }
        public static ResultObject GeneralErrorResult()
        {
            ResultObject result = new ResultObject()
            {
                Code = ((int)Errors.Codes.GeneralError) + "",
                Data = new object(),
                Message = Errors.GetErrorMessage(Errors.Codes.GeneralError.ToString())
            };
            return result;
        }
    }
}