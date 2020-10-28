using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api.Models
{
    public class ModelWithCostAndProfit : Model
    {
        public decimal? Cost { get; set; }
        public decimal? Profit { get; set; }
    }
}