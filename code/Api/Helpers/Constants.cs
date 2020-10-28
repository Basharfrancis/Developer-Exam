using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api.Helpers
{
    public class Constants
    {
        public const int ColorRedId = 1;
        public const int TypeSuvId = 2;
        public const decimal DefaultProfitRatio = 0.15m;


        public static List<int> OfferRedCarsMonths = new List<int>() { 5 };
        public const decimal OfferRedCarsRatio = 0.2m;

        public static List<int> PremiumConvertiblesMonths = new List<int>() { 5 };
        public const decimal PremiumConvertiblesRatio = 0.1m;

        public static List<int> PremiumSuvMonths = new List<int>() { 9, 10, 11, 12, 1, 2, 3, 4 };
        public const decimal PremiumSuvRatio = 0.1m;
    }
}