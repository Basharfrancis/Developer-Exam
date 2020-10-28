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
    public class Models
    {
        public static ResultObject Add(Model model)
        {
            try
            {
                if (model == null)
                    throw new BusinessException(Errors.Codes.ModelNotExist);
                ABCEntities context = new ABCEntities();
                Colors.checkColor(model.ColorId, context);
                Types.checkType(model.TypeId, context);
                if (model.IsConvertible == null)
                    model.IsConvertible = 0;
                if (model.IsConvertible > 1)
                    model.IsConvertible = 1;
                checkUniqueModel(model.ColorId.Value, model.TypeId.Value, model.IsConvertible.Value, context);
                context.MODEL.Add(new MODEL()
                {
                    COLOR_ID = model.ColorId.Value,
                    CONVERTIBLE = model.IsConvertible.Value,
                    TYPE_ID = model.TypeId.Value
                });
                context.SaveChanges();
                return BasicWrapper.SuccessResult(new object());
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
        public static ResultObject GetProfitableList(int? month)
        {
            try
            {
                if (month == null)
                    throw new BusinessException(Errors.Codes.DateEmpty);
                ABCEntities context = new ABCEntities();
                List<MODEL_DETAILS> modelsDetails = context.MODEL_DETAILS.AsNoTracking().ToList();
                List<ModelWithCostAndProfit> modelsWithCostAndProfit = GeneralWrapper.CalculateCostsAndProfits(month.Value, modelsDetails);
                List<Model> result = new List<Model>();
                foreach (var model in modelsWithCostAndProfit)
                {
                    if (model.Profit <= 0)
                        continue;
                    result.Add(new Model()
                    {
                        ColorId = model.ColorId,
                        ColorName = model.ColorName,
                        Id = model.Id,
                        IsConvertible = model.IsConvertible,
                        Price = model.Price,
                        TypeId = model.TypeId,
                        TypeName = model.TypeName
                    });
                }
                return BasicWrapper.SuccessResult(result);
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
        public static ResultObject GetMostProfitableList(int? month)
        {
            try
            {
                if (month == null)
                    throw new BusinessException(Errors.Codes.DateEmpty);
                ABCEntities context = new ABCEntities();
                List<MODEL_DETAILS> modelsDetails = context.MODEL_DETAILS.AsNoTracking().ToList();
                List<ModelWithCostAndProfit> modelsWithCostAndProfit = GeneralWrapper.CalculateCostsAndProfits(month.Value, modelsDetails);
                ModelWithCostAndProfit modelWithMostProfit = modelsWithCostAndProfit.OrderByDescending(m => m.Profit).FirstOrDefault();
                List<ModelWithCostAndProfit> result = new List<ModelWithCostAndProfit>();
                if (modelWithMostProfit != null)
                    result = modelsWithCostAndProfit.Where(m => m.Profit == modelWithMostProfit.Profit).ToList();
                return BasicWrapper.SuccessResult(result);
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
        private static void checkUniqueModel(int colorId, int typeId, byte isConvertible, ABCEntities context)
        {
            var existedModel = context.MODEL.AsNoTracking().FirstOrDefault(m => m.COLOR_ID == colorId && m.TYPE_ID == typeId && m.CONVERTIBLE == isConvertible);
            if (existedModel != null)
                throw new BusinessException(Errors.Codes.ModelDuplicate);
        }
    }
}