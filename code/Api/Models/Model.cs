using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api.Models
{
    public class Model
    {
        /*
        table model to display all the informayion about the car
        */
        public int? Id { get; set; }
        public int? TypeId { get; set; }
        public int? ColorId { get; set; }
        public String TypeName { get; set; }
        public String ColorName { get; set; }
        public decimal? Price { get; set; }
        public byte? IsConvertible { get; set; }
    }
}