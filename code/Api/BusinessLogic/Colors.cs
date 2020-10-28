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
    public class Colors
    {
        public static ResultObject GetColors()
        {
            // try
            // {
                ABCEntities context = new ABCEntities();
                List<COLOR> colors = context.COLOR.AsNoTracking().ToList();
                return BasicWrapper.SuccessResult(GeneralWrapper.Colors(colors));
            // }
            // catch (BusinessException exp)
            // {
            //     return BasicWrapper.ErrorResult(exp.Code, exp.Message);
            // }
            // catch (Exception exp)
            // {
            //     return BasicWrapper.GeneralErrorResult();
            // }
        }
        
        public static void checkColor(int? id, ABCEntities context)
        {
            if (id == null)
                throw new BusinessException(Errors.Codes.ColorNotExist);
            var item = context.COLOR.AsNoTracking().FirstOrDefault(i => i.ID == id);
            if (item == null)
                throw new BusinessException(Errors.Codes.ColorNotExist);
        }
    }
}