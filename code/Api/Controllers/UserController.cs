using Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Api.Controllers
{
    [RoutePrefix("User")]
    public class UserController : ApiController
    {
        /*
        display all the cars that we have to the users basied on thier month input
        */
        [Route("GetList")]
        [HttpPost]
        public ResultObject GetList([FromBody] Input input)
        {
            return BusinessLogic.Models.GetProfitableList(input.Month);
        }
    }
}