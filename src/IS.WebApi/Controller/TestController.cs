using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;

namespace IS.WebApi.Controller
{
    [Route("test")]
    public class TestController : ApiController
    {
        // GET api/<controller>
        public IHttpActionResult Get()
        {
            var caller = User as ClaimsPrincipal;

            return Json(new
            {
                message = "ok",
                client = caller.FindFirst("client_id").Value

            });
        }
    }
}