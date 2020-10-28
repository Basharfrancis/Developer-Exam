using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api.Exceptions
{
    public class Errors
    {
        public static String GetErrorMessage(String messageCode)
        {
            return MessagesEn.ResourceManager.GetString(messageCode);
        }
        public enum Codes
        {
            Success = 1,
            GeneralError = -1,
            ModelDuplicate = -2,
            ColorNotExist = -3,
            TypeNotExist = -4,
            ModelNotExist = -5,
            DateEmpty = -6
        }
    }
}