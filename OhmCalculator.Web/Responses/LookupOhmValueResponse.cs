using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OhmCalculator.Web.Responses
{
    public class LookupOhmValueResponse : ResponseBase
    {
        public int OhmValue { get; set; }
    }
}