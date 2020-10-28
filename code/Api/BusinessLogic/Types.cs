using Api.DBEntities;
using Api.Exceptions;
using Api.Models;
using Api.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api.BusinessLogic
{
    public class Types
    {
        public static ResultObject GetTypes()
        {
            try
            {
                ABCEntities context = new ABCEntities();
                List<TYPE> types = context.TYPE.AsNoTracking().ToList();
                return BasicWrapper.SuccessResult(GeneralWrapper.Types(types));
            }
            catch (BusinessException exp)
            {
                return BasicWrapper.ErrorResult(exp.Code, exp.Message);
            }
            catch (Exception exp)
            {
                return BasicWrapper.GeneralErrorResult();
            }
        }
        public static void checkType(int? id, ABCEntities context)
        {
            if (id == null)
                throw new BusinessException(Errors.Codes.TypeNotExist);
            var item = context.TYPE.AsNoTracking().FirstOrDefault(i => i.ID == id);
            if (item == null)
                throw new BusinessException(Errors.Codes.TypeNotExist);
        }
    }
}