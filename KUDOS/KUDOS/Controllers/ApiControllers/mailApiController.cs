using KUDOS.Controllers.InsertRequest;
using KUDOS.Response;
using KUDOS.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace KUDOS.Controllers.ApiControllers
{

    [RoutePrefix("api/mail")]
    public class mailApiController : ApiController
    {
        [HttpPost]
        [Route("send")]
        public HttpResponseMessage send(EmailInsertRequest model)
        {
            if (!ModelState.IsValid || model == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            EmailInsertRequest response = new EmailInsertRequest();

            response = MailServices.send(model);

            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}

