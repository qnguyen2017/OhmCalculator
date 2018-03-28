using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OhmCalculator.Web.Responses
{
    public class ResponseBase
    {
        public bool Status { get; set; }
        public string Message { get; set; }
    }
}