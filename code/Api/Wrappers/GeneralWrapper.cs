using Api.DBEntities;
using Api.Helpers;
using Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api.Wrappers
{
    public class GeneralWrapper
    {
        public static List<Color> Colors(List<COLOR> colors)
        {
            List<Color> result = new List<Color>();
            if (colors == null)
                return result;
            foreach (var c in colors)
                result.Add(new Color()
                {
                    Id = c.ID,
                    Name = c.NAME
                });
            return result;
        }
        public static List<Models.Type> Types(List<TYPE> types)
        {
            List<Models.Type> result = new List<Models.Type>();
            if (types == null)
                return result;
            foreach (var c in types)
                result.Add(new Models.Type()
                {
                    Id = c.ID,
                    Name = c.NAME
                });
            return result;
        }
        public static List<ModelWithCostAndProfit> CalculateCostsAndProfits(int month, List<MODEL_DETAILS> models)
        {
            List<ModelWithCostAndProfit> result = new List<ModelWithCostAndProfit>();
            if (models == null)
                return result;
            foreach (var m in models)
            {
                var modelWithCostAndProfit = new ModelWithCostAndProfit()
                {
                    ColorId = m.COLOR_ID,
                    ColorName = m.COLOR_NAME,
                    Id = m.MODEL_ID,
                    IsConvertible = m.MODEL_CONVERTIBLE,
                    TypeId = m.TYPE_ID,
                    TypeName = m.TYPE_NAME,
                    Cost = m.TYPE_COST,
                    Price = m.TYPE_COST * (1 + Constants.DefaultProfitRatio)
                };
                decimal offersAndPremiums = 1;
                if (Constants.OfferRedCarsMonths.Contains(month) && modelWithCostAndProfit.ColorId == Constants.ColorRedId)
                    offersAndPremiums -= Constants.OfferRedCarsRatio;
                if (Constants.PremiumConvertiblesMonths.Contains(month) && modelWithCostAndProfit.IsConvertible > 0)
                    offersAndPremiums += Constants.PremiumConvertiblesRatio;
                if (Constants.PremiumSuvMonths.Contains(month) && modelWithCostAndProfit.TypeId == Constants.TypeSuvId)
                    offersAndPremiums += Constants.PremiumSuvRatio;
                modelWithCostAndProfit.Price *= offersAndPremiums;
                modelWithCostAndProfit.Profit = modelWithCostAndProfit.Price - modelWithCostAndProfit.Cost;
                result.Add(modelWithCostAndProfit);
            }
            return result;
        }
    }
}