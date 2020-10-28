using Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Api.Controllers
{
    [RoutePrefix("Admin")]
    public class AdminController : ApiController
    {
        /*
        create post request 'GetColors' just to check the color we have
        
        */
        [Route("GetColors")]
        [HttpPost]
        public ResultObject GetColors([FromBody] Input input)
        {
            return BusinessLogic.Colors.GetColors();
        }

        /*
        create post request 'GetTypes' to check what types we have
        */
        [Route("GetTypes")]
        [HttpPost]
        public ResultObject GetTypes([FromBody] Input input)
        {
            return BusinessLogic.Types.GetTypes();
        }

        /*
        Get Most Profitable Models return the most cars has profit after selling in specicfic month
        */
        [Route("GetMostProfitableModels")]
        [HttpPost]
        public ResultObject GetMostProfitableModels([FromBody] Input input)
        {
            return BusinessLogic.Models.GetMostProfitableList(input.Month);
        }

        /*
        Add new Cars to the category with input of color , type and if convertable or not
        */
        [Route("AddModel")]
        [HttpPost]
        public ResultObject AddModel([FromBody] Input input)
        {
            return BusinessLogic.Models.Add(input.Model);
        }
    }
}