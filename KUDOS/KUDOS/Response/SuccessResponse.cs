using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KUDOS.Response
{
    public class SuccessResponse : BaseResponse
    {
        public SuccessResponse()
        {

            this.IsSuccessFul = true;
        }
    }
}