using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vehicle.Web.Areas.Admin.Models
{
    public class TokenModel
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public int expires_in { get; set; }
        public string key { get; set; }
    }
}